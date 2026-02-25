using Aco228.AIGen.Models;

namespace Aco228.AIGen.Gemini.Models;

public enum GoogleImageModelType
{
    [ModelType("gemini-2.5-flash-image")]
    Gemini2_5FlashImage = 1,
    
    [ModelType("gemini-3-pro-image-preview")]
    Gemini3Pro = 2,
}