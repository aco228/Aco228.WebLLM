using System.Text.Json.Serialization;

namespace Aco228.TextGen.DeepSeek.Models.Res;

public class MessageResponse
{
    public string id { get; set; }
    [JsonPropertyName("object")]
    public string Object { get; set; }
    public int created { get; set; }
    public string model { get; set; }
    public List<ChoiceDTO> choices { get; set; }
    public UsageDTO usage { get; set; }
    public string system_fingerprint { get; set; }
}


public class MessageDTO
{
    public string role { get; set; }
    public string content { get; set; }
}

public class ChoiceDTO
{
    public int index { get; set; }
    public MessageDTO message { get; set; }
    public object logprobs { get; set; }
    public string finish_reason { get; set; }
}

public class PromptTokensDetailsDTO
{
    public int cached_tokens { get; set; }
}

public class UsageDTO
{
    public int prompt_tokens { get; set; }
    public int completion_tokens { get; set; }
    public int total_tokens { get; set; }
    public PromptTokensDetailsDTO prompt_tokens_details { get; set; }
    public int prompt_cache_hit_tokens { get; set; }
    public int prompt_cache_miss_tokens { get; set; }
}
