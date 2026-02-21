namespace Aco228.AIGen.AtlasCloud.Models.Images;

public class AtlasCloudImageResponse
{
    public int code { get; set; }
    public string message { get; set; }
    public DataDTO data { get; set; }
}

public class UrlsDTO
{
    public string get { get; set; }
}

public class TimingsDTO
{
    public int inference { get; set; }
}

public class DataDTO
{
    public string id { get; set; }
    public string model { get; set; }
    public List<string>? outputs { get; set; }
    public UrlsDTO urls { get; set; }
    public object has_nsfw_contents { get; set; }
    public string status { get; set; } // completed, processing
    public string created_at { get; set; }
    public string error { get; set; }
    public int executionTime { get; set; }
    public TimingsDTO timings { get; set; }
}
