using Aco228.AIGen.Models;

namespace Aco228.AIGen.Gemini.Models;

public enum GoogleAiStudioModelType
{
    [ModelType("gemini-3.1-pro-preview")]
    Gemini3_1Pro,
    
    [ModelType("gemini-3-pro-preview")]
    Gemini3Pro,
    
    [ModelType("gemini-3-flash-preview")]
    Gemini3FlashPreview,
}