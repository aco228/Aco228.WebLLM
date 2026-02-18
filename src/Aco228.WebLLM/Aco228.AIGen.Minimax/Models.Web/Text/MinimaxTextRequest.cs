namespace Aco228.AIGen.Minimax.Models.Web.Text;

public class MinimaxTextRequest
{
    public required string model { get; set; }
    public List<MinimaxTextRequestMessage> messages { get; set; } = new();

    public MinimaxTextRequest AddMessage(string role, string message, List<string>? imageUrls = null)
    {
        var msg = new MinimaxTextRequestMessage() { role = role };
        msg.content.Add(new()
        {
            type = "text", 
            text = message
        });

        if (imageUrls != null && imageUrls.Any())
            foreach (var imageUrl in imageUrls)
                msg.content.Add(new() {type = "image_url", image_url = new() { url = imageUrl}});
        
        messages.Add(msg);
        return this;
    }
}

public class MinimaxTextRequestMessage
{
    public string role { get; set; } = "user";
    public List<MinimaxTextRequestMessageContent> content { get; set; } = new();
}

public class MinimaxTextRequestMessageContent
{
    public string type { get; set; } = "text";
    public string? text { get; set; } = null;
    public MinimaxTextRequestMessageContentImage? image_url { get; set; } = null;
}

public class MinimaxTextRequestMessageContentImage
{
    public string url { get; set; }
}