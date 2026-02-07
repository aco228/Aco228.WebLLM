using Aco228.AIGen.Models;
using Aco228.Common.Infrastructure;
using Aco228.Common.Models;

namespace Aco228.AIGen.Services;

public interface ITextGen : ITransient
{
    TextGenProvider Provider { get; }
    ManagedList<ModelDefinition> Models { get; }
    Task<TextGenResponse> Generate(TextGenRequest request);
}

public abstract class TextGenBase : ITextGen
{
    public abstract TextGenProvider Provider { get; }
    public ManagedList<ModelDefinition> Models { get; private set; } = new();

    public abstract void Prepare();
    protected abstract Task<TextGenResponse> ExecuteRequest(TextGenRequest request);

    public TextGenBase()
    {
        Prepare();
    }
    
    public Task<TextGenResponse> Generate(TextGenRequest request)
    {
        return ExecuteRequest(request);
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