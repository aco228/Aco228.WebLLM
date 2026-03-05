using Aco228.AIGen.Models;

namespace Aco228.AIGen.FalAi.Models;

public enum FalAiImageType
{
    [ModelType("fal-ai/bytedance/seedream/v5/lite/text-to-image")]
    Seadream5_lite,
    
    [ModelType("fal-ai/bytedance/seedream/v4.5/text-to-image")]
    Seadream4_5,
}