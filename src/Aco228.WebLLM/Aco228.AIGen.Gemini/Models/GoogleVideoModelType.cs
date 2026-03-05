using Aco228.AIGen.Models;

namespace Aco228.AIGen.Gemini.Models;

public enum GoogleVideoModelType
{
    [ModelType("veo-3.1-fast-generate-preview")]
    Veo3_1_Fast,
    
    [ModelType("veo-3.1-generate-preview")]
    Veo3_1,
}