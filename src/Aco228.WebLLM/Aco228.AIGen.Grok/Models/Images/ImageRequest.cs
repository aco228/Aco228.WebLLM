namespace Aco228.AIGen.Grok.Models.Images;

public class ImageRequest
{
    public string prompt { get; set; }
    public string model { get; set; } = "grok-imagine-image";
    public string response_format { get; set; } = "url";
    public string aspect_ratio { get; set; } = "1:1";
    public int n { get; set; } = 1;
}