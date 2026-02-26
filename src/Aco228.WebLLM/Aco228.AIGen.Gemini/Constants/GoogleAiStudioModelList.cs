using Aco228.AIGen.Gemini.Models;
using Aco228.AIGen.Models;

namespace Aco228.AIGen.Gemini.Constants;

internal static class GoogleAiStudioModelList
{
    public static List<ModelDefinition> Models = new()
    {
        new ModelDefinition
        {
            Provider = TextGenProvider.NanoBanana,
            PriceLevel = PriceLevel.High,
            Name = GoogleAiStudioModelType.Gemini3_1Pro.ToString(),
            ModelApiName = ModelTypeHelper.GetModelApiName(GoogleAiStudioModelType.Gemini3_1Pro),
            InputPricePerMillion = 2,
            OutputPricePerMillion = 12,
            Tier = ModelTier.High,
            IsVisionSupported = true,
            IsImageOutputSupported = false
        },
        new ModelDefinition
        {
            Provider = TextGenProvider.NanoBanana,
            PriceLevel = PriceLevel.High,
            Name = GoogleAiStudioModelType.Gemini3Pro.ToString(),
            ModelApiName = ModelTypeHelper.GetModelApiName(GoogleAiStudioModelType.Gemini3Pro),
            InputPricePerMillion = 2,
            OutputPricePerMillion = 12,
            Tier = ModelTier.High,
            IsVisionSupported = true,
            IsImageOutputSupported = false
        },
        new ModelDefinition
        {
            Provider = TextGenProvider.NanoBanana,
            PriceLevel = PriceLevel.Low,
            Name = GoogleAiStudioModelType.Gemini3FlashPreview.ToString(),
            ModelApiName = ModelTypeHelper.GetModelApiName(GoogleAiStudioModelType.Gemini3FlashPreview),
            InputPricePerMillion = 0.5,
            OutputPricePerMillion = 3,
            Tier = ModelTier.Mid,
            IsVisionSupported = true,
            IsImageOutputSupported = false
        },
    };

}