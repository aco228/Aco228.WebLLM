namespace Aco228.AIGen.Grok.Models.Video;

public class GrokVideoRequest
{
    public string model { get; set; } = "grok-imagine-video";
    public required string prompt { get; set; }
    public required int duration { get; set; }
    public required string resolution { get; set; }
    public required string aspect_ratio { get; set; } = "16:9";
}