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

    public override MessageRequest AddMessage(ModelRole role, string? content, List<string>? fileUrls = null)
    {
        throw new NotImplementedException();
    }
}

public class DeepSeekChatRequestMessage
{
    public string role { get; set; }
    public string content { get; set; }
}