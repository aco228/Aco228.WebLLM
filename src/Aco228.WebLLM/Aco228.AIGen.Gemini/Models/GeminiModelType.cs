using Aco228.AIGen.Models;

namespace Aco228.AIGen.Gemini.Models;

public enum GeminiModelType
{
    [ModelType("gemini-3-pro-preview")]
    Gemini3ProPreview,
    
    [ModelType("gemini-3-flash-preview")]
    Gemini3FlashPreview,
    
    [ModelType("gemini-2.5-flash")]
    Gemini2_5Flash,
    
    [ModelType("gemini-2.5-flash-lite")]
    Gemini2_5FlashLite,
}