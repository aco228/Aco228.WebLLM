using Aco228.AIGen.Models;
using Aco228.Common;
using Aco228.Common.Infrastructure;
using Aco228.Common.Models;

namespace Aco228.AIGen.Services;

public interface ITextGenManager : ISingleton
{
    List<ModelDefinition> ModelDefinitions { get; }
    List<TextGenProvider> Providers { get; }
    Task<string> GetText(TextGenerationRequest request);
    Task<TextGenResponse> GetResponse(TextGenerationRequest request);
    void Register<T>(TextGenProvider provider, List<ModelDefinition> models) where T : ITextGen;
}

public class TextGenManager : ITextGenManager
{
    ManagedList<ITextGen> _textGens = new();
    public List<ModelDefinition> ModelDefinitions { get; private set; } = new();
    public List<TextGenProvider> Providers => ModelDefinitions.Select(x => x.Provider).Distinct().ToList();


    public async Task<TextGenResponse> GetResponse(TextGenerationRequest request)
    {
        ITextGen? textGen = null;
        if (request.Model != null || request.Type != null)
        {
            if (request.Model != null)
                textGen = _textGens.FirstOrDefault(x => x.Provider == request.Model.Provider && x.Models.Any(y => y.ModelApiName == request.Model.ModelApiName));
            else if (request.Type != null)
                textGen = _textGens.FirstOrDefault(x => x.Provider == request.Type);
            
            if(textGen == null)
                throw new Exception("No text gen available for model " + request.Model?.ModelApiName);
        }
        
        if(textGen == null)
            textGen = _textGens.Take();
        
        if(textGen == null) 
            throw new  Exception("No text gen available");

        var textGenRequest = new TextGenRequest()
        {
            Model = request.Model?.ModelApiName ?? textGen.Models.TakeRandom(x => x.Level is ModelLevel.Low or ModelLevel.Mid)?.ModelApiName,
            User = request.User,
            System = request.System,
            ImageUrls = request.ImageUrls,
        };
        
        if(string.IsNullOrEmpty(textGenRequest.Model))
            throw new Exception("No model specified");
        
        var textGenResponse = await textGen.Generate(textGenRequest);
        return textGenResponse;
    }
    
    public async Task<string> GetText(TextGenerationRequest request)
    {
        var response = await GetResponse(request);
        return response.Response;
    }
    
    public void Register<T>(TextGenProvider provider, List<ModelDefinition> models) where T : ITextGen
    {
        var service = ServiceProviderHelper.GetServiceByType(typeof(T)) as ITextGen;
        _textGens.Add(service!);
        ModelDefinitions.AddRange(models);
    }
}