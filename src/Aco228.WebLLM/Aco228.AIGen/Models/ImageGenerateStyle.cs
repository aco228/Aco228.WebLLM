using Aco228.AIGen.Attributes;

namespace Aco228.AIGen.Models;

public class ImageGenerateStyle
{
    [PromptHint("Meta description what is essential for this image generation, what is about and what it must have (maximum 1 short sentence)")]
    public string About { get; set; }
    
    [PromptHint("What style suits best this kind of image?")]
    [PromptExample("photography")]
    public string Style { get; set; } = "realistic";

    public bool IsValid()
    {
        if (string.IsNullOrEmpty(About)
            || string.IsNullOrEmpty(Style))
            return false;

        return true;
    }   
}