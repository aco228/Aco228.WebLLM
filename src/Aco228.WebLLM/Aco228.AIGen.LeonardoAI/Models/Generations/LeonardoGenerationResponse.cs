using System.Text.Json.Serialization;

namespace Aco228.AIGen.LeonardoAI.Models.Generations;

public class LeonardoGenerationResponse
{
    [JsonPropertyName("sdGenerationJob")]
    public LenaordoGenerationJob Job { get; set; }
}


public class LeonardoGenerationCostDTO
{
    public string amount { get; set; }
    public string unit { get; set; }
}

public class LenaordoGenerationJob
{
    public string generationId { get; set; }
    public object apiCreditCost { get; set; }
    public LeonardoGenerationCostDTO cost { get; set; }
}
