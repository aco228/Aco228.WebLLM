using Aco228.AIGen.Models;
using Aco228.AIGen.OpenRouter.Models;

namespace Aco228.AIGen.OpenRouter.Constants;

internal static class OpenRouterImageModelList
{
    public static List<ModelImageDefinition> Models = new()
    {
        new ModelImageDefinition()
        {
            Provider = ImageGenProvider.OpenRouter,
            ModelApiName = ModelTypeHelper.GetModelApiName(OpenRouterImageModelType.RiverFlowV2Pro),
            PriceLevel = PriceLevel.Low,
            Tier = ModelTier.High,
            Name = OpenRouterImageModelType.RiverFlowV2Pro.ToString(),
            PricePerRequest = 0.15
        },
    };
}