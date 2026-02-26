using Aco228.AIGen.Models;
using Aco228.AIGen.Recraft.Models;

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
            ModelApiName = ModelTypeHelper.GetModelApiName(RecraftModelType.RecraftV3),
            PricePerRequest = 0.04
        },
        
        new ModelImageDefinition
        {
            Provider = ImageGenProvider.Recraft,
            PriceLevel = PriceLevel.Mid,
            Tier = ModelTier.High,
            Name = "Recraft V4",
            ModelApiName = ModelTypeHelper.GetModelApiName(RecraftModelType.RecraftV4),
            PricePerRequest = 0.04
        },
        
        new ModelImageDefinition
        {
            Provider = ImageGenProvider.Recraft,
            PriceLevel = PriceLevel.High,
            Tier = ModelTier.High,
            Name = "Recraft V4 Pro",
            ModelApiName = ModelTypeHelper.GetModelApiName(RecraftModelType.RecraftV4Pro),
            PricePerRequest = 0.25
        },
        

    };
}