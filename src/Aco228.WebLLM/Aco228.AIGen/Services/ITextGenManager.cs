using Aco228.AIGen.Models;
using Aco228.Common;
using Aco228.Common.Infrastructure;
using Aco228.Common.Models;

namespace Aco228.AIGen.Services;

public interface ITextGenManager : ISingleton
{
    List<ModelDefinition> ModelDefinitions { get; }
    Task<string> Generate(TextGenerationRequest request);
    Task<string> Generate(TextGenType type, string prompt);
    Task<string> Generate(TextGenType type, string system, string prompt);
    Task<string> Generate(TextGenType type, string model, string system, string prompt);
    Task<string> Generate(ModelDefinition definition, string system, string prompt);
    
    void Register<T>(TextGenType type, List<ModelDefinition> models) where T : ITextGen;
}

public class TextGenManager : ITextGenManager
{
    ManagedList<ITextGen> _textGens = new();
    public List<ModelDefinition> ModelDefinitions { get; private set; } = new();

    public async Task<string> Generate(TextGenerationRequest request)
    {
        ITextGen? textGen = null;
        if (request.Model != null)
            textGen = _textGens.FirstOrDefault(x => x.Type == request.Model.Provider && x.Models.Any(y => y.ModelApiName == request.Model.ModelApiName));
        if(textGen == null && request.Type != null)
            textGen = _textGens.FirstOrDefault(x => x.Type == request.Type);
        
        if(textGen == null)
            textGen = _textGens.Take();
        
        if(textGen == null) throw new  Exception("No text gen available");
        
        return await textGen.Generate(request);       
    }

    public Task<string> Generate(TextGenType type, string prompt)
    {
        var textGen = _textGens.FirstOrDefault(x => x.Type == type);
        if (textGen == null)
            return Task.FromResult("");
        
        return textGen.Generate(prompt);
    }
    
    public Task<string> Generate(TextGenType type, string system, string prompt)
    {
        var textGen = _textGens.FirstOrDefault(x => x.Type == type);
        if (textGen == null)
            return Task.FromResult("");
        
        return textGen.Generate(system, prompt);
    }

    public Task<string> Generate(TextGenType type, string model, string system, string prompt)
    {
        var textGen = _textGens.FirstOrDefault(x => x.Type == type);
        if (textGen == null)
            return Task.FromResult("");
        
        return textGen.Generate(model, system, prompt);
    }

    public Task<string> Generate(ModelDefinition definition, string system, string prompt)
        => Generate(definition.Provider, definition.ModelApiName, system, prompt);

    public void Register<T>(TextGenType type, List<ModelDefinition> models) where T : ITextGen
    {
        var service = ServiceProviderHelper.GetServiceByType(typeof(T)) as ITextGen;
        _textGens.Add(service!);
        ModelDefinitions.AddRange(models);
    }
}