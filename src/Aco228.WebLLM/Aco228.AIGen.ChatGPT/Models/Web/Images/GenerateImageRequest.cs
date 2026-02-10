using System.Text.Json.Serialization;

namespace Aco228.AIGen.ChatGPT.Models.Web.Images;

public class GenerateImageRequest
{
    public string model { get; set; } = "gpt-image-1.5";
    public required string prompt { get; set; }
    
    [JsonPropertyName("background")]
    public string background { get; set; } = "opaque";
    public string moderation { get; set; } = "auto";
    public string output_format { get; set; } = "png";
    
    [JsonPropertyName("n")]
    public int Count { get; set; } = 1;
    
    public string size { get; set; } = "1024x1024";
}