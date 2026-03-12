using Aco228.AIGen.Models;

namespace Aco228.AIGen.FalAi.Models;

public enum FalAiImageType
{
    [ModelType("bytedance/seedream/v5/lite/text-to-image")]
    Seadream5_lite,
    
    [ModelType("bytedance/seedream/v4.5/text-to-image")]
    Seadream4_5,
    
    [ModelType("flux-2-pro")]
    Flux2Pro,
    
    [ModelType("flux-2-max")]
    Flux2Max,
    
    [ModelType("flux-2/turbo")]
    Flux2Turbo,
    
    [ModelType("flux/dev")]
    FluxDev,
    
    [ModelType("flux/schnell")]
    FluxSchnell,
    
    [ModelType("z-image/turbo")]
    ZImageTurbo,
    
    [ModelType("qwen-image-2/pro/text-to-image")]
    QwenImage2Pro,
}