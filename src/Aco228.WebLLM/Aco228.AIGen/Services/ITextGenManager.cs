using Aco228.AIGen.Models;
using Aco228.Common;
using Aco228.Common.Models;

namespace Aco228.AIGen.Services;

public interface ITextGenManager : ISingleton
{
    List<ModelDefinition> ModelDefinitions { get; }
    Task<string> Generate(TextGenType type, string prompt);
    Task<string> Generate(TextGenType type, string system, string prompt);
    Task<string> Generate(TextGenType type, string model, string system, string prompt);
    Task<string> Generate(ModelDefinition definition, string system, string prompt);
    
    void Register<T>(TextGenType type, List<ModelDefinition> models) where T : ITextGen;
}

public class TextGenManager : ITextGenManager
{
    Dictionary<TextGenType, ITextGen> _textGens = new();
    public List<ModelDefinition> ModelDefinitions { get; private set; } = new();

    public Task<string> Generate(TextGenType type, string prompt)
    {
        if(!_textGens.TryGetValue(type, out var textGen))
            return Task.FromResult("");
        
        return textGen.Generate(prompt);
    }
    
    public Task<string> Generate(TextGenType type, string system, string prompt)
    {
        if(!_textGens.TryGetValue(type, out var textGen))
            return Task.FromResult("");
        
        return textGen.Generate(system, prompt);
    }

    public Task<string> Generate(TextGenType type, string model, string system, string prompt)
    {
        if(!_textGens.TryGetValue(type, out var textGen))
            return Task.FromResult("");
        
        return textGen.Generate(model, system, prompt);
    }

    public Task<string> Generate(ModelDefinition definition, string system, string prompt)
        => Generate(definition.Provider, definition.ModelApiName, system, prompt);

    public void Register<T>(TextGenType type, List<ModelDefinition> models) where T : ITextGen
    {
        var service = ServiceProviderHelper.GetServiceByType(typeof(T)) as ITextGen;
        _textGens.Add(type, service!);
        ModelDefinitions.AddRange(models);
    }
}