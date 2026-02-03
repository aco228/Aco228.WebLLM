using Aco228.AIGen.Models;

namespace Aco228.TextGen.DeepSeek.Models.Req;

public class MessageRequest : TextGenApiRequestBase<MessageRequest>
{
    public string model { get; set; } = "deepseek-chat";
    public int max_tokens { get; set; } = 8192; 
    public List<DeepSeekChatRequestMessage> messages { get; set; } = new();
    public bool stream { get; set; } = false;
    
    
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
        
        messages.Add(new DeepSeekChatRequestMessage {role = role.ToString(), content = content});
        return this;
    }
}

public class DeepSeekChatRequestMessage
{
    public string role { get; set; }
    public string content { get; set; }
}