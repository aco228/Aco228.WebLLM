using Aco228.AIGen.Models;

namespace Aco228.AIGen.Grok.Models;

public enum GrokModelType
{
    [ModelType("grok-4-0709")]
    Grok4Pro,
    
    [ModelType("grok-4-1-fast-non-reasoning")]
    Grok4_1FastNonReasoning,
    
    [ModelType("grok-code-fast-1")]
    GrokCodeFast1,
    
    [ModelType("grok-3-mini")]
    Grok3Mini,
}