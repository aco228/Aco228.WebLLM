using Aco228.AIGen.Models;

namespace Aco228.TextGen.Claude.Models.Web.Request;

public class MessageRequest : TextGenApiRequestBase<MessageRequest>
{
    public string model { get; set; }
    public uint max_tokens { get; set; } = 8000;
    
    public List<MessageRequestContent> messages { get; set; } = new();

    public override MessageRequest UseModel(string? model)
    {
        if (string.IsNullOrEmpty(model)) return this;
        this.model = model;
        return this;
    }

    public override MessageRequest AddMessage(ModelRole role, string? content, List<string>? fileUrls = null)
    {
        throw new NotImplementedException();
    }
}

public class MessageRequestContent
{
    public string role { get; set; }
    public string content { get; set; }
}