using Aco228.AIGen.Models;

namespace Aco228.AIGen.BlackForestLabs.Constants;

internal static class BlackForestImageModels
{
    public static List<ModelImageDefinition> Models = new()
    {
        new ModelImageDefinition
        {
            Provider = ImageGenProvider.BlackForestLabs,
            PriceLevel = PriceLevel.Low,
            Tier = ModelTier.High,
            Name = "FLUX.2 Klein 4B",
            ModelApiName = "flux-2-klein-4b",
            PricePerRequest = 0.014
        },
        new ModelImageDefinition
        {
            Provider = ImageGenProvider.BlackForestLabs,
            PriceLevel = PriceLevel.Low,
            Tier = ModelTier.High,
            Name = "FLUX.2 Klein 9B",
            ModelApiName = "flux-2-klein-9b",
            PricePerRequest = 0.015
        },
        new ModelImageDefinition
        {
            Provider = ImageGenProvider.BlackForestLabs,
            PriceLevel = PriceLevel.Mid,
            Tier = ModelTier.Mid,
            Name = "FLUX.2 Pro",
            ModelApiName = "flux-2-pro",
            PricePerRequest = 0.03
        },
        new ModelImageDefinition
        {
            Provider = ImageGenProvider.BlackForestLabs,
            PriceLevel = PriceLevel.High,
            Tier = ModelTier.High,
            Name = "FLUX.2 Max",
            ModelApiName = "flux-2-max",
            PricePerRequest = 0.05
        },
        new ModelImageDefinition
        {
            Provider = ImageGenProvider.BlackForestLabs,
            PriceLevel = PriceLevel.High,
            Tier = ModelTier.High,
            Name = "FLUX.2 Flex",
            ModelApiName = "flux-2-flex",
            PricePerRequest = 0.05
        },
        
      
    };
}