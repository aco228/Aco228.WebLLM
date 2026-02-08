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
    ModelDefinition GetModelDefinition(Enum modelType);
    void Register<T>(TextGenProvider provider, List<ModelDefinition> models) where T : ITextGen;
}

public class TextGenManager : ITextGenManager
{
    ManagedList<ITextGen> _textGens = new();
    public List<ModelDefinition> ModelDefinitions { get; private set; } = new();
    public List<TextGenProvider> Providers => ModelDefinitions.Select(x => x.Provider).Distinct().ToList();

    public async Task<TextGenResponse> GetResponse(TextGenerationRequest request)
    {
        ITextGen? textGen = GetTextGeneratorFromRequest(request);
        ModelDefinition? modelDefinition = GetModelDefinitionFromRequest(request, textGen);
        
        if(modelDefinition == null || textGen == null)
            throw new Exception("No suitable model found");

        var textGenRequest = new TextGenRequest()
        {
            Model = modelDefinition,
            User = request.User,
            System = request.System,
            ImageUrls = request.ImageUrls,
        };
        
        var textGenResponse = await textGen.Generate(textGenRequest);
        if (string.IsNullOrEmpty(textGenResponse.Response))
            throw new Exception("No response from text gen");
        
        textGenResponse.InputCost = (textGenResponse.InputTokens / 1_000_000.0) * modelDefinition.InputPricePerMillion;
        textGenResponse.OuputCost = (textGenResponse.OutputTokens / 1_000_000.0) * modelDefinition.OutputPricePerMillion;
        return textGenResponse;
    }

    private ModelDefinition? GetModelDefinitionFromRequest(TextGenerationRequest request, ITextGen? textGen)
    {
        ModelDefinition? modelDefinition;
        if(!string.IsNullOrEmpty(request.ModelName))
            modelDefinition = ModelDefinitions.FirstOrDefault(x =>  x.ModelApiName == request.ModelName && x.Provider == textGen.Provider);
        else if (request.Model != null)
            modelDefinition = request.Model;
        else
            modelDefinition = textGen.Models.TakeRandom(x => x.Level is ModelLevel.Low or ModelLevel.Mid);
        
        if (modelDefinition == null)
            throw new Exception("No model available");
        return modelDefinition;
    }

    private ITextGen? GetTextGeneratorFromRequest(TextGenerationRequest request)
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
        return textGen;
    }

    public ModelDefinition GetModelDefinition(Enum modelType)
    {
        var modelName = ModelTypeHelper.GetModelApiName(modelType);
        return _textGens.SelectMany(x => x.Models).FirstOrDefault(x => x.ModelApiName == modelName);
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