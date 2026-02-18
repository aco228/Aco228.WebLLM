namespace Aco228.AIGen.Minimax.Models.Web.Image;

public class MinimaxImageResponse
{
    public string id { get; set; }
    public DataDTO data { get; set; }
    public MetadataDTO metadata { get; set; }
    public BaseRespDTO base_resp { get; set; }
}

public class DataDTO
{
    public List<string> image_urls { get; set; }
}

public class MetadataDTO
{
    public string failed_count { get; set; }
    public string success_count { get; set; }
}

public class BaseRespDTO
{
    public int status_code { get; set; }
    public string status_msg { get; set; }
}
