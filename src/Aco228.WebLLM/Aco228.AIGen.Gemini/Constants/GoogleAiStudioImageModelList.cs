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
            Name = GoogleImageModelType.Gemini2_5FlashImage.ToString(),
            ModelApiName = ModelTypeHelper.GetModelApiName(GoogleImageModelType.Gemini2_5FlashImage),
            PricePerRequest = 0.014
        },
        new ModelImageDefinition
        {
            Provider = ImageGenProvider.GoogleAiStudio,
            PriceLevel = PriceLevel.Low,
            Tier = ModelTier.High,
            Name = GoogleImageModelType.Gemini3Pro.ToString(),
            ModelApiName = ModelTypeHelper.GetModelApiName(GoogleImageModelType.Gemini3Pro),
            PricePerRequest = 0.014
        },
        new ModelImageDefinition
        {
            Provider = ImageGenProvider.GoogleAiStudio,
            PriceLevel = PriceLevel.Low,
            Tier = ModelTier.High,
            Name = GoogleImageModelType.Gemini3_1Flash.ToString(),
            ModelApiName = ModelTypeHelper.GetModelApiName(GoogleImageModelType.Gemini3_1Flash),
            PricePerRequest = 0.014
        },
    };
}