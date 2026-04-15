using Aco228.AIGen.Models;

namespace Aco228.AIGen.FalAi.Models;

public enum FalAiImageType
{
    [ModelType("bytedance/seedream/v5/lite/text-to-image")]
    Seadream5_lite,
    
    [ModelType("bytedance/seedream/v5/lite/edit")]
    Seadream5_lite_edit,
    
    [ModelType("bytedance/seedream/v4.5/text-to-image")]
    Seadream4_5,
    
    [ModelType("flux-2-pro")]
    Flux2Pro,
    
    [ModelType("flux-2-max")]
    Flux2Max,
    
    [ModelType("flux-2-pro/edit")]
    Flux2ProEdit,
    
    [ModelType("flux-2-max/edit")]
    Flux2MaxEdit,
    
    [ModelType("nano-banana-2/edit")]
    NanoBanana2Edit,
    
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
    
    [ModelType("wan/v2.7/pro/text-to-image")]
    WanPro,
    
    [ModelType("wan/v2.7/text-to-image")]
    Wan,
    
    [ModelType("phota")]
    Phota,
    
    [ModelType("lumina-image/v2")]
    LuminaImage,
    
    [ModelType("ernie-image")]
    Ernie,
    
    [ModelType("ernie-image/turbo")]
    ErnieTurbo,
}