namespace Aco228.AIGen.LeonardoAI.Models;

public class LeonardoModelResponse
{
    public List<LeonardoModelDTO> custom_models { get; set; }
}

public class LeonardoModelDTO
{
    public string id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public bool nsfw { get; set; }
    public bool featured { get; set; }
    public LeonardoModelImageDTO generated_image { get; set; }
}


public class LeonardoModelImageDTO
{
    public string id { get; set; }
    public string url { get; set; }
}