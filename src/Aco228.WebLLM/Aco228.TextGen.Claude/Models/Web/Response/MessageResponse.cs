namespace Aco228.TextGen.Claude.Models.Web.Response;

public class MessageResponse
{
    public string model { get; set; }
    public string id { get; set; }
    public string type { get; set; }
    public string role { get; set; }
    public List<ContentDTO> content { get; set; }
    public string stop_reason { get; set; }
    public object stop_sequence { get; set; }
    public UsageDTO usage { get; set; }
}


public class ContentDTO
{
    public string type { get; set; }
    public string text { get; set; }
}

public class CacheCreationDTO
{
    public int ephemeral_5m_input_tokens { get; set; }
    public int ephemeral_1h_input_tokens { get; set; }
}

public class UsageDTO
{
    public int input_tokens { get; set; }
    public int cache_creation_input_tokens { get; set; }
    public int cache_read_input_tokens { get; set; }
    public CacheCreationDTO cache_creation { get; set; }
    public int output_tokens { get; set; }
    public string service_tier { get; set; }
}
