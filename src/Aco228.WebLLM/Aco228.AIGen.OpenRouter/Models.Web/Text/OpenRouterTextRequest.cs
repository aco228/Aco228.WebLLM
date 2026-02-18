namespace Aco228.AIGen.OpenRouter.Models.Web.Text;

public class OpenRouterTextRequest
{
    public string model { get; set; }
    public List<OpenRouterTextRequestMessage> input { get; set; } = new();
}

public class OpenRouterTextRequestMessage
{
    public string type { get; set; } = "text";
    public string role { get; set; }
    public string content { get; set; }
}