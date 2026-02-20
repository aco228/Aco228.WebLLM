using Aco228.AIGen.Attributes;

namespace Aco228.AIGen.Models;

public class ImageGenerateStyle
{
    [PromptHint("What would be the best prompt to generate background image",
        "Generate short 1 sentence (maximum 15 words) with generic meta prompt to generate best image for given topic")]
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