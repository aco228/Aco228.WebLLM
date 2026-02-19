namespace Aco228.AIGen.Models;

public class ImageGenerateStyle
{
    public string About { get; set; }
    public string Style { get; set; } = "realistic";

    public bool IsValid()
    {
        if (string.IsNullOrEmpty(About)
            || string.IsNullOrEmpty(Style))
            return false;

        return true;
    }   
}