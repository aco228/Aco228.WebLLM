using Aco228.AIGen.Models;

namespace Aco228.AIGen.Ideogram.Constants;

internal static class IdeogramImageModels
{
    public static List<ModelImageDefinition> Models = new()
    {
        new()
        {
            Provider = ImageGenProvider.Ideogram,
            ModelApiName = "ideogram-v3",
            PriceLevel = PriceLevel.High,
            Tier = ModelTier.High,
            Name = "Ideogram v3",
            PricePerRequest = 0.08,
        }
    };
}