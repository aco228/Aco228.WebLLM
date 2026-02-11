namespace Aco228.AIGen.Grok.Models.Images;

public class ImageResponse
{
    public List<DataDTO> data { get; set; }
}

public class DataDTO
{
    public string url { get; set; }
    public string revised_prompt { get; set; }
}
