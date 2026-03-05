using Aco228.AIGen.Gemini.Models.Gemini;

namespace Aco228.AIGen.Gemini.Models.GoogleAiStudio.Images;

public class GoogleAiImageRequest : RequestText
{
    public ImageGenerationConfig generationConfig { get; set; } = new();
}