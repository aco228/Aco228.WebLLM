using Aco228.AIGen.Models;

namespace Aco228.AIGen.Gemini.Models;

public enum GeminiModelType
{
    [ModelType("gemini-3.1-pro-preview")]
    GeminiPro,
    
    [ModelType("gemini-3-flash-preview")]
    GeminiFlash,
    
    [ModelType("gemini-3.1-flash-lite-preview")]
    GeminiLite,
}