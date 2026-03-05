namespace Aco228.AIGen.FalAi.Models.Web;

public class FalAiImageResponse
{
    public List<FalImageDTO> images { get; set; }
    public int seed { get; set; }
}

public class FalImageDTO
{
    public string url { get; set; }
    public string content_type { get; set; }
    public string file_name { get; set; }
    public int file_size { get; set; }
    public object width { get; set; }
    public object height { get; set; }
}