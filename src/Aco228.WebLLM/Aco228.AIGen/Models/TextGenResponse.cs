namespace Aco228.AIGen.Models;

public class TextGenResponse
{
    public TextGenProvider Type { get; set; }
    public string Response { get; set; } = "";
    public int InputTokens { get; set; }
    public int OutputTokens { get; set; }
    public double InputCost { get; set; }
    public double OuputCost { get; set; }
}