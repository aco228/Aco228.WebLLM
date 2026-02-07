using Aco228.AIGen.Models;

namespace Aco228.AIGen.Gemini.Constants;

internal static class GeminiModelList
{
    public static List<ModelDefinition> Models = new()
    {
        // Google Gemini - Pro Level
        new ModelDefinition
        {
            Provider = TextGenProvider.Gemini,
            Level = ModelLevel.Pro,
            Name = "Gemini 2.0 Flash",
            Description = "Google's latest multimodal model with native audio and video support",
            ModelApiName = "gemini-2.0-flash-001",
            MaxContextTokens = 1000000,
            IsVisionSupported = true,
            IsFileUploadSupported = true,
            SupportsJson = true,
            ParametersInBillions = 1000,
            InputPricePerMillion = 0.075,
            OutputPricePerMillion = 0.30
        },

        new ModelDefinition
        {
            Provider = TextGenProvider.Gemini,
            Level = ModelLevel.Pro,
            Name = "Gemini 1.5 Pro",
            Description = "Google's highly capable model with 2M token context",
            ModelApiName = "gemini-1.5-pro-002",
            MaxContextTokens = 2000000,
            IsVisionSupported = true,
            IsFileUploadSupported = true,
            SupportsJson = true,
            ParametersInBillions = 1000,
            InputPricePerMillion = 1.25,
            OutputPricePerMillion = 5.00
        },

// Google Gemini - Mid Level
        new ModelDefinition
        {
            Provider = TextGenProvider.Gemini,
            Level = ModelLevel.Mid,
            Name = "Gemini 1.5 Flash",
            Description = "Fast and efficient Google model with 1M token context",
            ModelApiName = "gemini-1.5-flash-002",
            MaxContextTokens = 1000000,
            IsVisionSupported = true,
            IsFileUploadSupported = true,
            SupportsJson = true,
            ParametersInBillions = 100,
            InputPricePerMillion = 0.075,
            OutputPricePerMillion = 0.30
        },

// Google Gemini - Low Level
        new ModelDefinition
        {
            Provider = TextGenProvider.Gemini,
            Level = ModelLevel.Low,
            Name = "Gemini 1.0 Pro",
            Description = "Google's lightweight general-purpose model",
            ModelApiName = "gemini-1.0-pro",
            MaxContextTokens = 32000,
            IsVisionSupported = false,
            IsFileUploadSupported = false,
            SupportsJson = true,
            ParametersInBillions = 100,
            InputPricePerMillion = 0.50,
            OutputPricePerMillion = 1.50
        },
    };
}