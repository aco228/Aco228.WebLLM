namespace Aco228.AIGen.PoyoAI.Models.Images;

public class ImageRequest
{
    public string model { get; set; }
    public string callback_url { get; set; }
    public ImageResponseInput input { get; set; } 
}

public class ImageResponseInput
{
    public string prompt { get; set; }
    public string size { get; set; } = "1:1";
    public int n { get; set; } = 1;
}