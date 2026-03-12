namespace Aco228.AIGen.FalAi.Models.Web;

public class FalImageRequest
{
    public string prompt { get; set; }
    public FalImageSize image_size { get; set; }
    public int num_images { get; set; } = 1;
}

public class FalImageSize
{
    public int width { get; set; }
    public int height { get; set; }
}