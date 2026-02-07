namespace Aco228.AIGen.Models;

public class TextGenResponse
{
    public required string Model { get; set; }
    public string UserPrompt { get; set; } = "";
    public string? SystemPrompt { get; set; } = "";
    public string Response { get; set; } = "";
    public int InputTokens { get; set; }
    public int OutputTokens { get; set; }
}