using Aco228.AIGen.Models;

namespace Aco228.AIGen.Minimax.Constants;

internal class MinimaxImageModels
{
    public static List<ModelImageDefinition> Models = new()
    {
        new ModelImageDefinition
        {
            Provider = ImageGenProvider.Minimax,
            PriceLevel = PriceLevel.Low,
            Tier = ModelTier.Mid,
            Name = "MiniMax Image 01",
            ModelApiName = "image-01",
            PricePerRequest = 0.0035
        }
    };
}