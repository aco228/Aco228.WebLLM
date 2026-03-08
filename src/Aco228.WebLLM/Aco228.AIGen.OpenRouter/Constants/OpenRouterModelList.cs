using Aco228.AIGen.Models;

namespace Aco228.AIGen.OpenRouter.Constants;

internal static class OpenRouterModelList
{
    public static List<ModelDefinition> Models = new()
    {
        new ModelDefinition()
        {
            Provider = TextGenProvider.OpenRouter,
            ModelApiName = "qwen/qwen3.5-flash-02-23",
            PriceLevel = PriceLevel.Low,
            Tier = ModelTier.High,
            Name = "qwen/qwen3.5-flash-02-23",
            ContextWindow = 1000000,
            IsVisionSupported = true,
            IsImageOutputSupported = false,
            InputPricePerMillion = 0.1,
            OutputPricePerMillion = 0.4,
        },
        new ModelDefinition()
        {
            Provider = TextGenProvider.OpenRouter,
            ModelApiName = "anthropic/claude-sonnet-4.6",
            PriceLevel = PriceLevel.High,
            Tier = ModelTier.High,
            Name = "anthropic/claude-sonnet-4.6",
            ContextWindow = 1000000,
            IsVisionSupported = true,
            IsImageOutputSupported = false,
            InputPricePerMillion = 3,
            OutputPricePerMillion = 15,
        },
        new ModelDefinition()
        {
            Provider = TextGenProvider.OpenRouter,
            ModelApiName = "minimax/minimax-m2.5",
            PriceLevel = PriceLevel.Low,
            Tier = ModelTier.High,
            Name = "minimax/minimax-m2.5",
            ContextWindow = 1000000,
            IsVisionSupported = true,
            IsImageOutputSupported = false,
            InputPricePerMillion = 0.2,
            OutputPricePerMillion = 1.2,
        },
        new ModelDefinition()
        {
            Provider = TextGenProvider.OpenRouter,
            ModelApiName = "z-ai/glm-5",
            PriceLevel = PriceLevel.Low,
            Tier = ModelTier.High,
            Name = "z-ai/glm-5",
            ContextWindow = 1000000,
            IsVisionSupported = true,
            IsImageOutputSupported = false,
            InputPricePerMillion = 0.8,
            OutputPricePerMillion = 2.56,
        },
        new ModelDefinition()
        {
            Provider = TextGenProvider.OpenRouter,
            ModelApiName = "moonshotai/kimi-k2.5",
            PriceLevel = PriceLevel.Low,
            Tier = ModelTier.High,
            Name = "moonshotai/kimi-k2.5",
            ContextWindow = 1000000,
            IsVisionSupported = true,
            IsImageOutputSupported = false,
            InputPricePerMillion = 0.45,
            OutputPricePerMillion = 2.2,
        },
        new ModelDefinition()
        {
            Provider = TextGenProvider.OpenRouter,
            ModelApiName = "z-ai/glm-4.7-flash",
            PriceLevel = PriceLevel.Low,
            Tier = ModelTier.High,
            Name = "z-ai/glm-4.7-flash",
            ContextWindow = 1000000,
            IsVisionSupported = true,
            IsImageOutputSupported = false,
            InputPricePerMillion = 0.06,
            OutputPricePerMillion = 0.4,
        },
        new ModelDefinition()
        {
            Provider = TextGenProvider.OpenRouter,
            ModelApiName = "mistralai/ministral-14b-2512",
            PriceLevel = PriceLevel.Low,
            Tier = ModelTier.High,
            Name = "mistralai/ministral-14b-2512",
            ContextWindow = 1000000,
            IsVisionSupported = true,
            IsImageOutputSupported = false,
            InputPricePerMillion = 0.2,
            OutputPricePerMillion = 0.2,
        },
        new ModelDefinition()
        {
            Provider = TextGenProvider.OpenRouter,
            ModelApiName = "deepseek/deepseek-v3.2",
            PriceLevel = PriceLevel.Low,
            Tier = ModelTier.High,
            Name = "deepseek/deepseek-v3.2",
            ContextWindow = 1000000,
            IsVisionSupported = true,
            IsImageOutputSupported = false,
            InputPricePerMillion = 0.25,
            OutputPricePerMillion = 0.4,
        },
    };
}