using Aco228.AIGen.Gemini.Models;
using Aco228.AIGen.Models;

namespace Aco228.AIGen.Gemini.Constants;

internal static class GoogleAiStudioImageModelList
{
    public static List<ModelImageDefinition> Models = new()
    {
        new ModelImageDefinition
        {
            Provider = ImageGenProvider.GoogleAiStudio,
            PriceLevel = PriceLevel.Low,
            Tier = ModelTier.High,
            Name = GoogleImageModelType.Gemini3Pro.ToString(),
            ModelApiName = ModelTypeHelper.GetModelApiName(GoogleImageModelType.Gemini3Pro),
            PricePerRequest = 0.014
        },
    };
}