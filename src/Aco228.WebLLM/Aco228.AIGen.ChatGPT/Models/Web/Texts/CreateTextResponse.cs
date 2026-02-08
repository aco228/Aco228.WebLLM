using System.Text.Json.Serialization;

namespace Aco228.AIGen.ChatGPT.Models.Web.Texts;

public class CreateTextResponse
{
    public string id { get; set; }
    [JsonPropertyName("object")]
    public string Object { get; set; }
    public int created_at { get; set; }
    public string status { get; set; }
    public bool background { get; set; }
    public BillingDTO billing { get; set; }
    public int completed_at { get; set; }
    public object error { get; set; }
    public decimal frequency_penalty { get; set; }
    public object incomplete_details { get; set; }
    public object instructions { get; set; }
    public object max_output_tokens { get; set; }
    public object max_tool_calls { get; set; }
    public string model { get; set; }
    public List<OutputDTO> output { get; set; }
    public bool parallel_tool_calls { get; set; }
    public decimal presence_penalty { get; set; }
    public object previous_response_id { get; set; }
    public object prompt_cache_key { get; set; }
    public object prompt_cache_retention { get; set; }
    public ReasoningDTO reasoning { get; set; }
    public object safety_identifier { get; set; }
    public string service_tier { get; set; }
    public bool store { get; set; }
    public decimal temperature { get; set; }
    public TextDTO text { get; set; }
    public string tool_choice { get; set; }
    public List<object> tools { get; set; }
    public int top_logprobs { get; set; }
    public decimal top_p { get; set; }
    public string truncation { get; set; }
    public UsageDTO usage { get; set; }
    public object user { get; set; }
    public MetadataDTO metadata { get; set; }
}


public class BillingDTO
{
    public string payer { get; set; }
}

public class ContentDTO
{
    public string type { get; set; }
    public List<object> annotations { get; set; }
    public List<object> logprobs { get; set; }
    public string text { get; set; }
}

public class OutputDTO
{
    public string id { get; set; }
    public string type { get; set; }
    public string status { get; set; }
    public List<ContentDTO>? content { get; set; }
    public string role { get; set; }
}

public class ReasoningDTO
{
    public object effort { get; set; }
    public object summary { get; set; }
}

public class FormatDTO
{
    public string type { get; set; }
}

public class TextDTO
{
    public FormatDTO format { get; set; }
    public string verbosity { get; set; }
}

public class InputTokensDetailsDTO
{
    public int cached_tokens { get; set; }
}

public class OutputTokensDetailsDTO
{
    public int reasoning_tokens { get; set; }
}

public class UsageDTO
{
    public int input_tokens { get; set; }
    public InputTokensDetailsDTO input_tokens_details { get; set; }
    public int output_tokens { get; set; }
    public OutputTokensDetailsDTO output_tokens_details { get; set; }
    public int total_tokens { get; set; }
}

public class MetadataDTO
{
}
