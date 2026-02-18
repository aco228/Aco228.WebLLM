using System.Text.Json.Serialization;

namespace Aco228.AIGen.OpenRouter.Models.Web.Text;

public class OpenRouterTextResponse
{
    [JsonPropertyName("object")]
    public string Object { get; set; }
    public string id { get; set; }
    public int created_at { get; set; }
    public string model { get; set; }
    public string status { get; set; }
    public int completed_at { get; set; }
    public object error { get; set; }
    public string output_text { get; set; }
    public List<OutputDTO> output { get; set; }
    public object incomplete_details { get; set; }
    public List<object> tools { get; set; }
    public string tool_choice { get; set; }
    public bool parallel_tool_calls { get; set; }
    public object max_output_tokens { get; set; }
    public int temperature { get; set; }
    public int top_p { get; set; }
    public int presence_penalty { get; set; }
    public int frequency_penalty { get; set; }
    public int top_logprobs { get; set; }
    public object max_tool_calls { get; set; }
    public bool background { get; set; }
    public object previous_response_id { get; set; }
    public string service_tier { get; set; }
    public string truncation { get; set; }
    public bool store { get; set; }
    public object instructions { get; set; }
    public TextDTO text { get; set; }
    public object reasoning { get; set; }
    public object safety_identifier { get; set; }
    public object prompt_cache_key { get; set; }
    public object user { get; set; }
    public UsageDTO usage { get; set; }
}


public class ContentDTO
{
    public string type { get; set; }
    public string text { get; set; }
    public List<object> annotations { get; set; }
    public List<object> logprobs { get; set; }
}

public class OutputDTO
{
    public string type { get; set; }
    public string id { get; set; }
    public List<object> summary { get; set; }
    public string encrypted_content { get; set; }
    public string format { get; set; }
    public string role { get; set; }
    public string status { get; set; }
    public List<ContentDTO> content { get; set; }
}

public class FormatDTO
{
    public string type { get; set; }
}

public class TextDTO
{
    public FormatDTO format { get; set; }
}

public class InputTokensDetailsDTO
{
    public int cached_tokens { get; set; }
}

public class OutputTokensDetailsDTO
{
    public int reasoning_tokens { get; set; }
}

public class CostDetailsDTO
{
    public decimal upstream_inference_cost { get; set; }
    public decimal upstream_inference_input_cost { get; set; }
    public decimal upstream_inference_output_cost { get; set; }
}

public class UsageDTO
{
    public int input_tokens { get; set; }
    public InputTokensDetailsDTO input_tokens_details { get; set; }
    public int output_tokens { get; set; }
    public OutputTokensDetailsDTO output_tokens_details { get; set; }
    public int total_tokens { get; set; }
    public decimal cost { get; set; }
    public bool is_byok { get; set; }
    public CostDetailsDTO cost_details { get; set; }
}
