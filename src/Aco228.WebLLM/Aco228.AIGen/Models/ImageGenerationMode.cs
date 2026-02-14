using System.ComponentModel;
using Aco228.Common.Extensions;

namespace Aco228.AIGen.Models;

public enum ImageGenerationMode
{
    [Description("Top 30% of image must be without any important focal point as it will be used design elements")]
    TOP = 1,
    
    [Description("Bottom 30% of image must be without any important focal point as it will be used design elements")]
    BOTTOM = 2,
    CENTER = 3,
    LEFT = 4,
    RIGHT = 5,
}

public static class ImageGenerationModeHelper
{
    public static string GetPrompt(this ImageGenerationMode mode)
    {
        var desc = mode.GetAttribute<DescriptionAttribute>();
        if (desc == null)
            throw new InvalidOperationException($"Missing attribute");
        
        return desc.Description;
    }
    
}