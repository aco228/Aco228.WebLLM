using Aco228.AIGen.Models;

namespace Aco228.AIGen.Recraft.Constants;

internal static class RecraftImageModels
{
    public static List<ModelImageDefinition> Models = new()
    {
        // Recraft V3 - confirmed model string: "recraftv3"
        new ModelImageDefinition
        {
            Provider = ImageGenProvider.Recraft,
            PriceLevel = PriceLevel.Mid,
            Tier = ModelTier.High,
            Name = "Recraft V3",
            ModelApiName = "recraftv3",
            PricePerRequest = 0.04
        },
        
        new ModelImageDefinition
        {
            Provider = ImageGenProvider.Recraft,
            PriceLevel = PriceLevel.Mid,
            Tier = ModelTier.High,
            Name = "Recraft V4",
            ModelApiName = "recraftv4",       // ⚠️ unconfirmed - verify against recraft.ai/docs
            PricePerRequest = 0.04
        },
        
        new ModelImageDefinition
        {
            Provider = ImageGenProvider.Recraft,
            PriceLevel = PriceLevel.High,
            Tier = ModelTier.High,
            Name = "Recraft V4 Pro",
            ModelApiName = "recraftv4_pro",    // ⚠️ unconfirmed
            PricePerRequest = 0.25
        },
        

    };
}