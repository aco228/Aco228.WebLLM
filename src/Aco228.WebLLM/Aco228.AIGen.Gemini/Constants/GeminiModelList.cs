using Aco228.AIGen.Gemini.Models;
using Aco228.AIGen.Models;

namespace Aco228.AIGen.Gemini.Constants;

internal static class GeminiModelList
{
    public static List<ModelDefinition> Models = new()
    {
        new ModelDefinition
        {
            Provider = TextGenProvider.Gemini,
            PriceLevel = PriceLevel.High,
            Name = GeminiModelType.GeminiPro.ToString(),
            ModelApiName = ModelTypeHelper.GetModelApiName(GeminiModelType.GeminiPro),
            InputPricePerMillion = 2,
            OutputPricePerMillion = 12,
            Tier = ModelTier.High,
            IsVisionSupported = true,
            IsImageOutputSupported = false
        },
        
        new ModelDefinition
        {
            Provider = TextGenProvider.Gemini,
            PriceLevel = PriceLevel.Mid,
            Name = GeminiModelType.GeminiFlash.ToString(),
            ModelApiName = ModelTypeHelper.GetModelApiName(GeminiModelType.GeminiFlash),
            InputPricePerMillion = 2,
            OutputPricePerMillion = 12,
            Tier = ModelTier.High,
            IsVisionSupported = false,
            IsImageOutputSupported = false
        },
        
        new ModelDefinition
        {
            Provider = TextGenProvider.Gemini,
            PriceLevel = PriceLevel.Low,
            Name = GeminiModelType.GeminiLite.ToString(),
            ModelApiName = ModelTypeHelper.GetModelApiName(GeminiModelType.GeminiLite),
            InputPricePerMillion = 0.25,
            OutputPricePerMillion = 1.5,
            Tier = ModelTier.High,
            IsVisionSupported = false,
            IsImageOutputSupported = false
        },
    };
}