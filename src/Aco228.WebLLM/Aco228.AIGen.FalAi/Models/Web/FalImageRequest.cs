namespace Aco228.AIGen.FalAi.Models.Web;

public class FalImageRequest
{
    public string prompt { get; set; }
    public FalImageSize? image_size { get; set; }
    public int num_images { get; set; } = 1;
    public string? image_url { get; set; }
    public string? aspect_ratio { get; set; }
    public List<string>? image_urls { get; set; }
}

public class FalImageSize
{
    public int width { get; set; }
    public int height { get; set; }
}