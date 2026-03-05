namespace Aco228.AIGen.FalAi.Models.Web;

public class FalImageRequest
{
    public string prompt { get; set; }
    public string image_size { get; set; }
    public int num_images { get; set; } = 1;
}