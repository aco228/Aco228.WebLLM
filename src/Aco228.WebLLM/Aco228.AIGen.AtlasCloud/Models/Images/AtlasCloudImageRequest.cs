namespace Aco228.AIGen.AtlasCloud.Models.Images;

public class AtlasCloudImageRequest
{
    public string prompt { get; set; } = "";
    public string aspect_ratio { get; set; } = "1:1";
    public string model { get; set; }
}