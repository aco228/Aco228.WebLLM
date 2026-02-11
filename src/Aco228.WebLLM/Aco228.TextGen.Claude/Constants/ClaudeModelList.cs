using Aco228.AIGen.Models;

namespace Aco228.TextGen.Claude.Constants;

internal static class ClaudeModelList
{
    public static List<ModelDefinition> Models = new List<ModelDefinition>()
    {
        new ModelDefinition
        {
            Provider = TextGenProvider.Claude,
            Level = ModelLevel.Pro,
            Name = "Claude Opus 4.5",
            ModelApiName = "claude-opus-4-6",
            InputPricePerMillion = 5,
            OutputPricePerMillion = 25
        },

        new ModelDefinition
        {
            Provider = TextGenProvider.Claude,
            Level = ModelLevel.Mid,
            Name = "Claude Sonnet 4.5",
            ModelApiName = "claude-sonnet-4-5-20250929",
            InputPricePerMillion = 3.00,
            OutputPricePerMillion = 15.00
        },

        new ModelDefinition
        {
            Provider = TextGenProvider.Claude,
            Level = ModelLevel.Low,
            Name = "Claude Haiku 4.5",
            ModelApiName = "claude-haiku-4-5-20251001",
            InputPricePerMillion = 1,
            OutputPricePerMillion = 5,
        },
    };
}