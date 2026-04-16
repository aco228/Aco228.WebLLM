using Aco228.AIGen.Models;
using Aco228.TextGen.Claude.Models;

namespace Aco228.TextGen.Claude.Constants;

internal static class ClaudeModelList
{
    public static List<ModelDefinition> Models = new List<ModelDefinition>()
    {
        new ModelDefinition
        {
            Provider = TextGenProvider.Claude,
            PriceLevel = PriceLevel.High,
            Name = ClaudeModelType.ClaudeOpus.ToString(),
            ModelApiName = ModelTypeHelper.GetModelApiName(ClaudeModelType.ClaudeOpus),
            InputPricePerMillion = 5,
            OutputPricePerMillion = 25,
            Tier = ModelTier.High,
            IsVisionSupported = true,
            IsImageOutputSupported = false
        },

        new ModelDefinition
        {
            Provider = TextGenProvider.Claude,
            PriceLevel = PriceLevel.Mid,
            Name = ClaudeModelType.ClaudeSonnet.ToString(),
            ModelApiName = ModelTypeHelper.GetModelApiName(ClaudeModelType.ClaudeSonnet),
            InputPricePerMillion = 3.00,
            OutputPricePerMillion = 15.00,
            Tier = ModelTier.High,
            IsVisionSupported = true,
            IsImageOutputSupported = false
        },

        new ModelDefinition
        {
            Provider = TextGenProvider.Claude,
            PriceLevel = PriceLevel.Low,
            Name = ClaudeModelType.ClaudeHaiku.ToString(),
            ModelApiName = ModelTypeHelper.GetModelApiName(ClaudeModelType.ClaudeHaiku),
            InputPricePerMillion = 1,
            OutputPricePerMillion = 5,
            Tier = ModelTier.High,
            IsVisionSupported = true,
            IsImageOutputSupported = false
        },
    };
}