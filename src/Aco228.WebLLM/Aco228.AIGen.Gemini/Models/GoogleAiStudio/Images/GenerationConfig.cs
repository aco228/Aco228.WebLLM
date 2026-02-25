namespace Aco228.AIGen.Gemini.Models.GoogleAiStudio.Images;

public class GenerationConfig
{
    public List<string> responseModalities { get; set; } = new() {"IMAGE"};
    public GenerationConfigConfig imageConfig { get; set; } = new();
}

public class GenerationConfigConfig
{
    public string aspectRatio { get; set; } = "1:1";
    public string imageSize { get; set; } = "2k";
}