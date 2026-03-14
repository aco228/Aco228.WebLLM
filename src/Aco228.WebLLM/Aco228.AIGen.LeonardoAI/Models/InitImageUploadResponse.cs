namespace Aco228.AIGen.LeonardoAI.Models;


public class InitImageUploadResponse
{
    public UploadinitimageDTO uploadInitImage { get; set; }
}

public class UploadinitimageDTO
{
    public string id { get; set; }
    public string fields { get; set; }
    public string key { get; set; }
    public string url { get; set; }
    public string __typename { get; set; }
}
