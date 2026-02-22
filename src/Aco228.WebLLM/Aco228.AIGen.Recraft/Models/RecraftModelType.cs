using Aco228.AIGen.Models;

namespace Aco228.AIGen.Recraft.Models;

public enum RecraftModelType
{
    [ModelType("recraftv4_pro")]
    RecraftV4Pro,
    
    [ModelType("recraftv4")]
    RecraftV4,
    
    [ModelType("recraftv3")]
    RecraftV3,
}