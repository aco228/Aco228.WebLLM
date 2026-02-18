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
            Name = "Claude Opus 4.6",
            ModelApiName = ModelTypeHelper.GetModelApiName(ClaudeModelType.ClaudeOpus4_6),
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
            Name = "Claude Sonnet 4.5",
            ModelApiName = ModelTypeHelper.GetModelApiName(ClaudeModelType.ClaudeSonnet4_5),
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
            Name = "Claude Haiku 4.5",
            ModelApiName = ModelTypeHelper.GetModelApiName(ClaudeModelType.ClaudeHaiku4_5),
            InputPricePerMillion = 1,
            OutputPricePerMillion = 5,
            Tier = ModelTier.High,
            IsVisionSupported = true,
            IsImageOutputSupported = false
        },
    };
}