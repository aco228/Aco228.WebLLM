using Aco228.AIGen.Attributes;

namespace Aco228.AIGen.Models;

public class ImageGenerateStyle
{
    [PromptHint("What style suits best this kind of image?")]
    [PromptExample("photography")]
    public string Style { get; set; } = "realistic";
    
    
    [PromptHint("What should be avoided so that image is realistic as a marketing ad?")]
    [PromptExample("futuristic, cyberpunk, neon, sci-fi, concept art, stylized, fantasy")]
    public string Negatives { get; set; } = "";

    public bool IsValid()
    {
        if (string.IsNullOrEmpty(Style))
            return false;

        return true;
    }   
}