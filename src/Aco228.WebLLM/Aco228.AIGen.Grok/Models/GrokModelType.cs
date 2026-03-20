using Aco228.AIGen.Models;

namespace Aco228.AIGen.Grok.Models;

public enum GrokModelType
{
    [ModelType("grok-4.20-0309-non-reasoning")]
    GrokPro,
    
    [ModelType("grok-4-1-fast-reasoning")]
    GrokMid,
    
    [ModelType("grok-4-1-fast-non-reasoning")]
    GrokMini,
}