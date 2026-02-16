
namespace Aco228.TextGen.Claude.Models.Web.Text;

public class MessageRequest
{
    public string model { get; set; }
    public uint max_tokens { get; set; } = 8000;
    public string? system { get; set; }
    
    public List<RequestMessage> messages { get; set; } = new();
    
    public void AddInput(string role, string content, List<string>? imageUrls = null)
    {
        var input = new RequestMessage()
        {
            role = role,
        };
        input.content.Add(new RequestMessageEntryText(content));
        
        if(imageUrls?.Any() == true)
            foreach (var imageUrl in imageUrls)
            {
                input.content.Add(new RequestMessageEntryImage(imageUrl));
            }
        
        messages.Add(input);
    }
}

public class RequestMessage
{
    public required string role { get; set; }
    public List<RequestMessageEntry> content { get; set; } = new();
}