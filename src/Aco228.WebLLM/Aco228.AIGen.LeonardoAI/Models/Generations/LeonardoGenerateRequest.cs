namespace Aco228.AIGen.LeonardoAI.Models.Generations;

public class LeonardoGenerateRequest
{
    public required string modelId { get; set; }
    public required int height { get; set; }
    public required int width { get; set; }
    public required string prompt { get; set; } = "";
    public int num_images { get; set; } = 1;
    // public string style_id { get; set; } = LeonardoStyles.Dynamic;
    public bool ultra { get; set; } = false;
    
    public List<LeonardoGenerationControlNets>? controlnets { get; set; }
}

public class LeonardoGenerationControlNets
{
    public required string initImageId { get; set; }
    public required int preprocessorId { get; set; }
    public string initImageType { get; set; } = "UPLOADED";
    public string strengthType { get; set; } = "High";
}