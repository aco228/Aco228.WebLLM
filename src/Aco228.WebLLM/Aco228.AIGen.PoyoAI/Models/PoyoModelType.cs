using Aco228.AIGen.Models;

namespace Aco228.AIGen.PoyoAI.Models;

public enum PoyoModelType
{
    [ModelType("gpt-4o-image")]
    gpt4o,
    
    [ModelType("gpt-image-1.5")]
    gpt1_5,
    
    [ModelType("nano-banana")]
    NanoBanana,
    
    [ModelType("nano-banana-2")]
    NanoBanana2,
    
    [ModelType("flux-2-pro")]
    Flux2Pro,
    
    [ModelType("flux-2-flex")]
    Flux2Flex,
    
    [ModelType("seedream-4.5")]
    Seadream4_5,
    
    [ModelType("z-image")]
    ZImage,
    
    [ModelType("grok-imagine-image")]
    GrokImage,
    
    
}