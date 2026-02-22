namespace Aco228.AIGen.Ideogram.Models.Image;

/// <summary>
/// https://developer.ideogram.ai/api-reference/api-reference/generate-v3
/// </summary>
public class IdeogramImageRequest
{
    public string prompt { get; set; }
    public string aspect_ratio { get; set; }
    public string magic_prompt { get; set; } = "ON";
    public string rendering_speed { get; set; } = "DEFAULT";
    public string style_type { get; set; } = "AUTO";
    public int num_images { get; set; } = 1;
}