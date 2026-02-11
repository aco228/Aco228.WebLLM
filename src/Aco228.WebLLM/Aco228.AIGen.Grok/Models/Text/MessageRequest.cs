
namespace Aco228.AIGen.Grok.Models.Text;

public class MessageRequest
{
    public List<GrokChatRequestMessage> messages { get; set; } = new();
    public string model { get; set; } = "grok-2-latest";
    public bool stream { get; set; } = false;
    public int temperature { get; set; } = 0;

    public MessageRequest AddInput(string role, string? content, List<string>? imageFiles = null)
    {   
        var message = new GrokChatRequestMessage()
        {
            role = role
        };

        message.content.Add(new GrokChatRequestMessageContent() { text = content });
        
        if(imageFiles?.Any() == true)
            foreach (var imgUrl in imageFiles)
            {
                message.content.Add(new ()
                {
                    type = "image_url",
                    image_url = new 
                    {
                        url = imgUrl
                    }
                });
            }
        
        messages.Add(message);
        return this;
    }
}

public class GrokChatRequestMessage
{
    public string role { get; set; } = "system";
    public List<GrokChatRequestMessageContent> content { get; set; } = new();
}

public class GrokChatRequestMessageContent
{
    public string type { get; set; } = "text";
    public string? text { get; set; }
    public object? image_url { get; set; } = null;

}