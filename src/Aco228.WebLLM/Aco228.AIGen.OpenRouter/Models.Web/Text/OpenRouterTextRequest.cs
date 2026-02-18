namespace Aco228.AIGen.OpenRouter.Models.Web.Text;

public class OpenRouterTextRequest
{
    public string model { get; set; }
    public List<OpenRouterTextRequestMessage> input { get; set; } = new();

    public OpenRouterTextRequest AddInput(string role, string message, List<string>? imageFiles = null)
    {
        var input = new OpenRouterTextRequestMessage()
        {
            role = role,
            content = new()
            {
                new()
                {
                    text = message,
                }
            }
        };

        if (imageFiles != null && imageFiles.Any())
            foreach (var imgUrl in imageFiles)
                input.content.Add(new()
                {
                    type = "input_image",
                    image_url = imgUrl
                });
        
        this.input.Add(input);
        return this;
    }
}

public class OpenRouterTextRequestMessage
{
    public string type { get; set; } = "message";
    public string role { get; set; }
    public List<OpenRouterTextRequestMessageContent> content { get; set; } = new();
}

public class OpenRouterTextRequestMessageContent
{
    public string type { get; set; } = "input_text";
    public string? text { get; set; }
    public string? image_url { get; set; }
}