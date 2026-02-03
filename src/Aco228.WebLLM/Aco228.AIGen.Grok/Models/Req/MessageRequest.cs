using Aco228.AIGen.Models;

namespace Aco228.AIGen.Grok.Models.Req;

public class MessageRequest : TextGenApiRequestBase<MessageRequest>
{
    public List<GrokChatRequestMessage> messages { get; set; } = new();
    public string model { get; set; } = "grok-2-latest";
    public bool stream { get; set; } = false;
    public int temperature { get; set; } = 0;
    
    public override MessageRequest UseModel(string? model)
    {
        if (string.IsNullOrEmpty(model))
            return this;
        
        this.model = model;
        return this;
    }

    public override MessageRequest AddMessage(ModelRole role, string content)
    {
        if (string.IsNullOrEmpty(content))
            return this;
        
        messages.Add(new GrokChatRequestMessage {role = role.ToString(), content = content});
        return this;
    }
}

public class GrokChatRequestMessage
{
    public string role { get; set; } = "system";
    public string content { get; set; }
}