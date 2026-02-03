using Aco228.AIGen.Models;
using Aco228.Common.Models;

namespace Aco228.AIGen.Services;

public interface ITextGen : ITransient
{
    TextGenType Type { get; }
    List<ModelDefinition> Models { get; }
    Task<string> Generate(ModelDefinition modelDefinition, string prompt);
    Task<string> Generate(string prompt);
    Task<string> Generate(string system, string prompt);
    Task<string> Generate(string model, string system, string prompt);
}

public abstract class TextGenBase : ITextGen
{
    public abstract TextGenType Type { get; }
    public List<ModelDefinition> Models { get; private set; } = new();

    public abstract Task<string> Generate(string prompt);
    public abstract Task<string> Generate(string system, string prompt);
    public abstract Task<string> Generate(string model, string system, string prompt);
    public abstract void Prepare();

    public TextGenBase()
    {
        Prepare();
    }
    
    public Task<string> Generate(ModelDefinition modelDefinition, string prompt)
    {
        if (modelDefinition.Provider != Type)
            throw new ArgumentException($"ModelDefinition provider {modelDefinition.Provider} does not match TextGen type {Type}");
        
        return Generate(prompt);
    }

    protected void AddModels(List<ModelDefinition> models)
    {
        foreach (var modelDefinition in models)
            if(!Models.Exists(x => x.ModelApiName == modelDefinition.ModelApiName))
                Models.Add(modelDefinition);
    }
    
    protected virtual ModelDefinition TakeNextModel() 
        => Models.Where(x => x.Level is ModelLevel.Low or ModelLevel.Mid).Shuffle().First();
}