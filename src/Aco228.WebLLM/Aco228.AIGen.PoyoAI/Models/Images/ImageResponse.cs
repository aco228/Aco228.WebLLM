namespace Aco228.AIGen.PoyoAI.Models.Images;

public class ImageResponse
{
    public int code { get; set; }
    public ImageResponseData data { get; set; }
}

public class ImageResponseData
{
    public string task_id { get; set; }
    public string status { get; set; }
    public DateTime created_time { get; set; }
    public int? progress { get; set; }
    public string? error_message { get; set; }
    public List<ImageResponseFile>? files { get; set; }
}

public class ImageResponseFile
{
    public string file_url { get; set; }
    public string file_type { get; set; }
}