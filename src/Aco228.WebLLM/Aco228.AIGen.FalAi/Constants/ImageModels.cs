using Aco228.AIGen.FalAi.Models;
using Aco228.AIGen.Models;

namespace Aco228.AIGen.FalAi.Constants;

internal static class ImageModels
{
    public static List<ModelImageDefinition> Models = new()
    {
        new()
        {
            Provider = ImageGenProvider.FalAi,
            ModelApiName = ModelTypeHelper.GetModelApiName(FalAiImageType.Seadream5_lite),
            PriceLevel = PriceLevel.High,
            Tier = ModelTier.High,
            Name = FalAiImageType.Seadream5_lite.ToString(),
            PricePerRequest = 0,
        },
        new()
        {
            Provider = ImageGenProvider.FalAi,
            ModelApiName = ModelTypeHelper.GetModelApiName(FalAiImageType.Seadream4_5),
            PriceLevel = PriceLevel.High,
            Tier = ModelTier.High,
            Name = FalAiImageType.Seadream4_5.ToString(),
            PricePerRequest = 0,
        },
    };
}