namespace Aco228.AIGen.Models;

public class TextGenerationRequest
{
    public TextGenType? Type { get; set; }
    public ModelDefinition? Model { get; set; }
    public string Prompt { get; set; }
    public string? System { get; set; }
    public List<string> FileUrls { get; set; } = new();
}