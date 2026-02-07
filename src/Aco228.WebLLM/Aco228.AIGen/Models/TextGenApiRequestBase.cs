namespace Aco228.AIGen.Models;

public abstract class TextGenApiRequestBase<T> where T : class
{

    public T UseModel(ModelDefinition? model) => UseModel(model?.ModelApiName);
    
    public abstract T UseModel(string? model);
    
    public abstract T AddMessage(ModelRole role, string? content, List<string>? fileUrls = null);

}