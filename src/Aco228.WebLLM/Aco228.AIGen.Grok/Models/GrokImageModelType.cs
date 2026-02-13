using Aco228.AIGen.Models;

namespace Aco228.AIGen.Grok.Models;

public enum GrokImageModelType
{
    [ModelType("grok-imagine-image-pro")]
    GrokImagineImagePro,
    
    [ModelType("grok-imagine-image")]
    GrokImagineImage,
    
    [ModelType("grok-2-image-1212")]
    Grok2Image,
    
}