namespace Aco228.AIGen.OpenRouter.Models.Web.Models;

public class OpenRouterModelDto
{
    public List<DataDTO> data { get; set; }
}

public class DataDTO
{
    public string id { get; set; }
    public string canonical_slug { get; set; }
    public string hugging_face_id { get; set; }
    public string name { get; set; }
    public int created { get; set; }
    public string description { get; set; }
    public int context_length { get; set; }
    public ArchitectureDTO architecture { get; set; }
    public PricingDTO pricing { get; set; }
    public TopProviderDTO top_provider { get; set; }
    public object per_request_limits { get; set; }
    public List<string> supported_parameters { get; set; }
    public DefaultParametersDTO default_parameters { get; set; }
    public string expiration_date { get; set; }
}

public class ArchitectureDTO
{
    public string modality { get; set; }
    public List<string> input_modalities { get; set; }
    public List<string> output_modalities { get; set; }
    public string tokenizer { get; set; }
    public object instruct_type { get; set; }
}

public class PricingDTO
{
    public string prompt { get; set; }
    public string completion { get; set; }
    public string web_search { get; set; }
    public string input_cache_read { get; set; }
    public string input_cache_write { get; set; }
    
    public double GetPromptPrice() => double.TryParse(prompt, out var result) ? result : 0;
    public double GetOutputPrice() => double.TryParse(completion, out var result) ? result : 0;
}

public class TopProviderDTO
{
    public int context_length { get; set; }
    public int max_completion_tokens { get; set; }
    public bool is_moderated { get; set; }
}

public class DefaultParametersDTO
{
    public object temperature { get; set; }
    public object top_p { get; set; }
    public object frequency_penalty { get; set; }
}
