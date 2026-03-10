using Aco228.AIGen.LeonardoAI.Models;
using Aco228.AIGen.Models;

namespace Aco228.AIGen.LeonardoAI.Constants;

internal static class LeonardoImageModels
{
    public static List<ModelImageDefinition> Models = new()
    {
        new()
        {
            ModelApiName = ModelTypeHelper.GetModelApiName(LeonardoImageModelType.LucidOrigin),
            Name = LeonardoImageModelType.LucidOrigin.ToString(),
            PriceLevel = PriceLevel.Mid,
            Provider = ImageGenProvider.LeonardoAI,
            PricePerRequest = 0.001,
            Tier = ModelTier.Mid,
        }
    };
}