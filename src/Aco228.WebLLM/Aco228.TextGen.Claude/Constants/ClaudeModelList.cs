using Aco228.AIGen.Models;

namespace Aco228.TextGen.Claude.Constants;

internal static class ClaudeModelList
{
    public static List<ModelDefinition> Models = new List<ModelDefinition>()
    {
        // Claude - Pro Level (Current - Claude 4.5 family)
        new ModelDefinition
        {
            Provider = TextGenType.Claude,
            Level = ModelLevel.Pro,
            Name = "Claude Opus 4.5",
            Description = "Anthropic's most capable model - best for complex tasks and coding",
            ModelApiName = "claude-opus-4-5-20251101",
            MaxContextTokens = 200000,
            IsVisionSupported = true,
            IsFileUploadSupported = true,
            SupportsJson = true,
            ParametersInBillions = 200,
            InputPricePerMillion = 15.00,
            OutputPricePerMillion = 75.00
        },

// Claude - Mid Level (Current - Claude 4.5 family)
        new ModelDefinition
        {
            Provider = TextGenType.Claude,
            Level = ModelLevel.Mid,
            Name = "Claude Sonnet 4.5",
            Description = "Balanced latest generation Claude model - recommended for most use cases",
            ModelApiName = "claude-sonnet-4-5-20250929",
            MaxContextTokens = 200000,
            IsVisionSupported = true,
            IsFileUploadSupported = true,
            SupportsJson = true,
            ParametersInBillions = 100,
            InputPricePerMillion = 3.00,
            OutputPricePerMillion = 15.00
        },

        new ModelDefinition
        {
            Provider = TextGenType.Claude,
            Level = ModelLevel.Mid,
            Name = "Claude Sonnet 4",
            Description = "Latest Sonnet model with strong performance for coding and tasks",
            ModelApiName = "claude-sonnet-4-20250514",
            MaxContextTokens = 200000,
            IsVisionSupported = true,
            IsFileUploadSupported = true,
            SupportsJson = true,
            ParametersInBillions = 100,
            InputPricePerMillion = 3.00,
            OutputPricePerMillion = 15.00
        },

// Claude - Low Level (Current - Claude 4.5 family)
        new ModelDefinition
        {
            Provider = TextGenType.Claude,
            Level = ModelLevel.Low,
            Name = "Claude Haiku 4.5",
            Description = "Latest compact and fast Claude model",
            ModelApiName = "claude-haiku-4-5-20251001",
            MaxContextTokens = 200000,
            IsVisionSupported = true,
            IsFileUploadSupported = true,
            SupportsJson = true,
            ParametersInBillions = 8,
            InputPricePerMillion = 0.80,
            OutputPricePerMillion = 4.00
        },

        new ModelDefinition
        {
            Provider = TextGenType.Claude,
            Level = ModelLevel.Low,
            Name = "Claude 3.5 Haiku",
            Description = "Haiku model with vision support",
            ModelApiName = "claude-3-5-haiku-20241022",
            MaxContextTokens = 200000,
            IsVisionSupported = true,
            IsFileUploadSupported = true,
            SupportsJson = true,
            ParametersInBillions = 8,
            InputPricePerMillion = 0.80,
            OutputPricePerMillion = 4.00
        },
    };
}