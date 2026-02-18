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
            Name = GeminiModelType.Gemini3ProPreview.ToString(),
            ModelApiName = ModelTypeHelper.GetModelApiName(GeminiModelType.Gemini3ProPreview),
            InputPricePerMillion = 2,
            OutputPricePerMillion = 12
        },
        
        new ModelDefinition
        {
            Provider = TextGenProvider.Gemini,
            PriceLevel = PriceLevel.Mid,
            Name = GeminiModelType.Gemini3FlashPreview.ToString(),
            ModelApiName = ModelTypeHelper.GetModelApiName(GeminiModelType.Gemini3FlashPreview),
            InputPricePerMillion = 0.5,
            OutputPricePerMillion = 3
        },
        
        new ModelDefinition
        {
            Provider = TextGenProvider.Gemini,
            PriceLevel = PriceLevel.Low,
            Name = GeminiModelType.Gemini2_5Flash.ToString(),
            ModelApiName = ModelTypeHelper.GetModelApiName(GeminiModelType.Gemini2_5Flash),
            InputPricePerMillion = 0.5,
            OutputPricePerMillion = 3
        },
        
        new ModelDefinition
        {
            Provider = TextGenProvider.Gemini,
            PriceLevel = PriceLevel.Low,
            Name = GeminiModelType.Gemini2_5FlashLite.ToString(),
            ModelApiName = ModelTypeHelper.GetModelApiName(GeminiModelType.Gemini2_5FlashLite),
            InputPricePerMillion = 0.5,
            OutputPricePerMillion = 3
        },
    };
}