using System.Text.Json.Serialization;

namespace Aco228.AIGen.Minimax.Models.Web.Text;

public class MinimaxTextResponse
{
    public string id { get; set; }
    public List<ChoiceDTO> choices { get; set; }
    public int created { get; set; }
    public string model { get; set; }
    [JsonPropertyName("object")]
    public string Object { get; set; }
    public UsageDTO usage { get; set; }
    public bool input_sensitive { get; set; }
    public bool output_sensitive { get; set; }
    public int input_sensitive_type { get; set; }
    public int output_sensitive_type { get; set; }
    public int output_sensitive_int { get; set; }
    public BaseRespDTO base_resp { get; set; }
}


public class ReasoningDetailDTO
{
    public string type { get; set; }
    public string id { get; set; }
    public string format { get; set; }
    public int index { get; set; }
    public string text { get; set; }
}

public class MessageDTO
{
    public string content { get; set; }
    public string role { get; set; }
    public string name { get; set; }
    public string audio_content { get; set; }
    public string reasoning_content { get; set; }
    public List<ReasoningDetailDTO> reasoning_details { get; set; }
}

public class ChoiceDTO
{
    public string finish_reason { get; set; }
    public int index { get; set; }
    public MessageDTO message { get; set; }
}

public class CompletionTokensDetailsDTO
{
    public int reasoning_tokens { get; set; }
}

public class UsageDTO
{
    public int total_tokens { get; set; }
    public int total_characters { get; set; }
    public int prompt_tokens { get; set; }
    public int completion_tokens { get; set; }
    public CompletionTokensDetailsDTO completion_tokens_details { get; set; }
}

public class BaseRespDTO
{
    public int status_code { get; set; }
    public string status_msg { get; set; }
}
