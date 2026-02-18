using Aco228.AIGen.Models;

namespace Aco228.AIGen.Minimax.Constants;

internal static class MinimaxTextModels
{
    public static List<ModelDefinition> Models = new()
    {
        // MiniMax-M2.5 (standard speed ~50 TPS)
        new ModelDefinition
        {
            Provider = TextGenProvider.Minimax,
            PriceLevel = PriceLevel.Low,
            Tier = ModelTier.High,
            Name = "MiniMax M2.5",
            ModelApiName = "MiniMax-M2.5",
            Description =
                "SOTA frontier model for real-world productivity. Excels in coding (80.2% SWE-Bench), agentic tool use, and office work. ~50 TPS.",
            ContextWindow = 204800,
            IsVisionSupported = false,
            IsImageOutputSupported = false,
            InputPricePerMillion = 0.15,
            OutputPricePerMillion = 0.60
        },

        // MiniMax-M2.5-highspeed (Lightning ~100 TPS)
        new ModelDefinition
        {
            Provider = TextGenProvider.Minimax,
            PriceLevel = PriceLevel.Low,
            Tier = ModelTier.High,
            Name = "MiniMax M2.5 Highspeed",
            ModelApiName = "MiniMax-M2.5-highspeed",
            Description = "Same capability as M2.5 but at ~100 TPS. Twice the speed of mainstream frontier models.",
            ContextWindow = 204800,
            IsVisionSupported = false,
            IsImageOutputSupported = false,
            InputPricePerMillion = 0.30,
            OutputPricePerMillion = 2.40
        },

        // MiniMax-M2.1
        new ModelDefinition
        {
            Provider = TextGenProvider.Minimax,
            PriceLevel = PriceLevel.Low,
            Tier = ModelTier.Mid,
            Name = "MiniMax M2.1",
            ModelApiName = "MiniMax-M2.1",
            Description =
                "Enhanced model focused on multi-language programming. Outperforms Claude Sonnet 4.5 on multilingual coding tasks. ~60 TPS.",
            ContextWindow = 204800,
            IsVisionSupported = false,
            IsImageOutputSupported = false,
            InputPricePerMillion = 0.30,
            OutputPricePerMillion = 1.20
        },

        // MiniMax-M2.1-highspeed
        new ModelDefinition
        {
            Provider = TextGenProvider.Minimax,
            PriceLevel = PriceLevel.Low,
            Tier = ModelTier.Mid,
            Name = "MiniMax M2.1 Highspeed",
            ModelApiName = "MiniMax-M2.1-highspeed",
            Description = "Faster variant of M2.1. Same capability at ~100 TPS.",
            ContextWindow = 204800,
            IsVisionSupported = false,
            IsImageOutputSupported = false,
            InputPricePerMillion = 0.30,
            OutputPricePerMillion = 1.20
        },

        // MiniMax-M2
        new ModelDefinition
        {
            Provider = TextGenProvider.Minimax,
            PriceLevel = PriceLevel.Low,
            Tier = ModelTier.Mid,
            Name = "MiniMax M2",
            ModelApiName = "MiniMax-M2",
            Description =
                "Open-source model built for agents and coding. 230B total / 10B active params. Strong tool use, deep search, and long-chain task execution.",
            ContextWindow = 204800,
            IsVisionSupported = false,
            IsImageOutputSupported = false,
            InputPricePerMillion = 0.30,
            OutputPricePerMillion = 1.20
        },
    };
}