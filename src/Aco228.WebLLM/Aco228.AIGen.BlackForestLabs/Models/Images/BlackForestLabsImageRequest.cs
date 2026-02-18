namespace Aco228.AIGen.BlackForestLabs.Models.Images;

public class BlackForestLabsImageRequest
{
    public string output_format { get; set; } = "png";
    public string prompt { get; set; }
    public int width { get; set; }
    public int height { get; set; }
}