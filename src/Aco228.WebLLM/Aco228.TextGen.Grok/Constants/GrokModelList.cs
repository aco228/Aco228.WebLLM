using Aco228.AIGen.Models;

namespace Aco228.TextGen.Grok.Constants;

internal static class GrokModelList
{
    public static List<ModelDefinition> Models = new()
    {
        new ModelDefinition
        {
            Provider = TextGenType.Grok,
            Level = ModelLevel.Pro,
            Name = "Grok 4.1 Fast Reasoning",
            Description = "xAI's latest fast reasoning model with 2M context",
            ModelApiName = "grok-4-1-fast-reasoning",
            MaxContextTokens = 2000000,
            IsVisionSupported = false,
            IsFileUploadSupported = false,
            SupportsJson = true,
            ParametersInBillions = 300,
            InputPricePerMillion = 0.20,
            OutputPricePerMillion = 0.50
        },

        new ModelDefinition
        {
            Provider = TextGenType.Grok,
            Level = ModelLevel.Pro,
            Name = "Grok 4.1 Fast Non-Reasoning",
            Description = "xAI's fast model without extended reasoning with 2M context",
            ModelApiName = "grok-4-1-fast-non-reasoning",
            MaxContextTokens = 2000000,
            IsVisionSupported = false,
            IsFileUploadSupported = false,
            SupportsJson = true,
            ParametersInBillions = 300,
            InputPricePerMillion = 0.20,
            OutputPricePerMillion = 0.50
        },

        new ModelDefinition
        {
            Provider = TextGenType.Grok,
            Level = ModelLevel.Pro,
            Name = "Grok 4 Fast Reasoning",
            Description = "xAI's fast reasoning model with 2M context",
            ModelApiName = "grok-4-fast-reasoning",
            MaxContextTokens = 2000000,
            IsVisionSupported = false,
            IsFileUploadSupported = false,
            SupportsJson = true,
            ParametersInBillions = 300,
            InputPricePerMillion = 0.20,
            OutputPricePerMillion = 0.50
        },

        new ModelDefinition
        {
            Provider = TextGenType.Grok,
            Level = ModelLevel.Pro,
            Name = "Grok 4 Fast Non-Reasoning",
            Description = "xAI's fast model without extended reasoning with 2M context",
            ModelApiName = "grok-4-fast-non-reasoning",
            MaxContextTokens = 2000000,
            IsVisionSupported = false,
            IsFileUploadSupported = false,
            SupportsJson = true,
            ParametersInBillions = 300,
            InputPricePerMillion = 0.20,
            OutputPricePerMillion = 0.50
        },

        new ModelDefinition
        {
            Provider = TextGenType.Grok,
            Level = ModelLevel.Pro,
            Name = "Grok 4 0709",
            Description = "xAI's advanced model snapshot from 0709",
            ModelApiName = "grok-4-0709",
            MaxContextTokens = 256000,
            IsVisionSupported = false,
            IsFileUploadSupported = false,
            SupportsJson = true,
            ParametersInBillions = 300,
            InputPricePerMillion = 3.00,
            OutputPricePerMillion = 15.00
        },

// Grok - Mid Level
        new ModelDefinition
        {
            Provider = TextGenType.Grok,
            Level = ModelLevel.Mid,
            Name = "Grok 3",
            Description = "xAI's capable model with 131K context",
            ModelApiName = "grok-3",
            MaxContextTokens = 131072,
            IsVisionSupported = false,
            IsFileUploadSupported = false,
            SupportsJson = true,
            ParametersInBillions = 300,
            InputPricePerMillion = 3.00,
            OutputPricePerMillion = 15.00
        },

        new ModelDefinition
        {
            Provider = TextGenType.Grok,
            Level = ModelLevel.Mid,
            Name = "Grok Code Fast",
            Description = "xAI's optimized model for code with 256K context",
            ModelApiName = "grok-code-fast-1",
            MaxContextTokens = 256000,
            IsVisionSupported = false,
            IsFileUploadSupported = false,
            SupportsJson = true,
            ParametersInBillions = 300,
            InputPricePerMillion = 0.20,
            OutputPricePerMillion = 1.50
        },

// Grok - Low Level
        new ModelDefinition
        {
            Provider = TextGenType.Grok,
            Level = ModelLevel.Low,
            Name = "Grok 3 Mini",
            Description = "xAI's lightweight and fast model with 131K context",
            ModelApiName = "grok-3-mini",
            MaxContextTokens = 131072,
            IsVisionSupported = false,
            IsFileUploadSupported = false,
            SupportsJson = true,
            ParametersInBillions = 100,
            InputPricePerMillion = 0.30,
            OutputPricePerMillion = 0.50
        },

        new ModelDefinition
        {
            Provider = TextGenType.Grok,
            Level = ModelLevel.Low,
            Name = "Grok 2 Vision",
            Description = "xAI's model with vision capabilities and 32K context",
            ModelApiName = "grok-2-vision-1212",
            MaxContextTokens = 32768,
            IsVisionSupported = true,
            IsFileUploadSupported = false,
            SupportsJson = true,
            ParametersInBillions = 300,
            InputPricePerMillion = 2.00,
            OutputPricePerMillion = 10.00
        },
    };
}