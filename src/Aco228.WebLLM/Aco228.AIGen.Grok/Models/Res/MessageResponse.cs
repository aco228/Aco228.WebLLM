using System.Text.Json.Serialization;

namespace Aco228.AIGen.Grok.Models.Res;

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
    public string reasoning_content { get; set; }
    public object refusal { get; set; }
}

public class ChoiceDTO
{
    public int index { get; set; }
    public MessageDTO message { get; set; }
    public string finish_reason { get; set; }
}

public class PromptTokensDetailsDTO
{
    public int text_tokens { get; set; }
    public int audio_tokens { get; set; }
    public int image_tokens { get; set; }
    public int cached_tokens { get; set; }
}

public class CompletionTokensDetailsDTO
{
    public int reasoning_tokens { get; set; }
    public int audio_tokens { get; set; }
    public int accepted_prediction_tokens { get; set; }
    public int rejected_prediction_tokens { get; set; }
}

public class UsageDTO
{
    public int prompt_tokens { get; set; }
    public int completion_tokens { get; set; }
    public int total_tokens { get; set; }
    public PromptTokensDetailsDTO prompt_tokens_details { get; set; }
    public CompletionTokensDetailsDTO completion_tokens_details { get; set; }
    public int num_sources_used { get; set; }
    public int cost_in_usd_ticks { get; set; }
}
