using System.Text.Json.Serialization;

namespace Aco228.TextGen.Perplexity.Models.Web;

public class SonarResponse
{
    public string id { get; set; }
    public string model { get; set; }
    public int created { get; set; }
    public UsageDTO usage { get; set; }
    public List<string> citations { get; set; }
    public List<SearchResultDTO> search_results { get; set; }
    [JsonPropertyName("object")]
    public string Object { get; set; }
    public List<ChoiceDTO> choices { get; set; }
}


public class CostDTO
{
    public decimal input_tokens_cost { get; set; }
    public decimal output_tokens_cost { get; set; }
    public decimal request_cost { get; set; }
    public decimal total_cost { get; set; }
}

public class UsageDTO
{
    public int prompt_tokens { get; set; }
    public int completion_tokens { get; set; }
    public int total_tokens { get; set; }
    public string search_context_size { get; set; }
    public CostDTO cost { get; set; }
}

public class SearchResultDTO
{
    public string title { get; set; }
    public string url { get; set; }
    public string date { get; set; }
    public string last_updated { get; set; }
    public string snippet { get; set; }
    public string source { get; set; }
}

public class MessageDTO
{
    public string role { get; set; }
    public string content { get; set; }
}

public class DeltaDTO
{
    public string role { get; set; }
    public string content { get; set; }
}

public class ChoiceDTO
{
    public int index { get; set; }
    public MessageDTO message { get; set; }
    public DeltaDTO delta { get; set; }
    public string finish_reason { get; set; }
}
