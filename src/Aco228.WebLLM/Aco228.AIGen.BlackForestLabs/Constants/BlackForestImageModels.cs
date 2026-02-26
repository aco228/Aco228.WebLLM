using Aco228.AIGen.BlackForestLabs.Models;
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
            Name = FluxImageModelType.FluxKlein4b.ToString(),
            ModelApiName = ModelTypeHelper.GetModelApiName(FluxImageModelType.FluxKlein4b),
            PricePerRequest = 0.014
        },
        new ModelImageDefinition
        {
            Provider = ImageGenProvider.BlackForestLabs,
            PriceLevel = PriceLevel.Low,
            Tier = ModelTier.High,
            Name = "FLUX.2 Klein 9B",
            ModelApiName = ModelTypeHelper.GetModelApiName(FluxImageModelType.FluxKlein9b),
            PricePerRequest = 0.015
        },
        new ModelImageDefinition
        {
            Provider = ImageGenProvider.BlackForestLabs,
            PriceLevel = PriceLevel.Mid,
            Tier = ModelTier.Mid,
            Name = "FLUX.2 Pro",
            ModelApiName = ModelTypeHelper.GetModelApiName(FluxImageModelType.Flux2Pro),
            PricePerRequest = 0.03
        },
        new ModelImageDefinition
        {
            Provider = ImageGenProvider.BlackForestLabs,
            PriceLevel = PriceLevel.High,
            Tier = ModelTier.High,
            Name = "FLUX.2 Max",
            ModelApiName = ModelTypeHelper.GetModelApiName(FluxImageModelType.Flux2Max),
            PricePerRequest = 0.07
        },
        new ModelImageDefinition
        {
            Provider = ImageGenProvider.BlackForestLabs,
            PriceLevel = PriceLevel.High,
            Tier = ModelTier.High,
            Name = "FLUX.2 Flex",
            ModelApiName = ModelTypeHelper.GetModelApiName(FluxImageModelType.Flux2Flex),
            PricePerRequest = 0.05
        },
        
      
    };
}