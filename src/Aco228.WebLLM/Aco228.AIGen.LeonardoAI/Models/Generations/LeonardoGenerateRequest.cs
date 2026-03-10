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
}