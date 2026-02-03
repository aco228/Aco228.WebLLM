using Aco228.AIGen.Models;

namespace Aco228.AIGen.ChatGPT.Constants;

internal static class ChatGptModelList
{
    public static List<ModelDefinition> Models = new()
    {
        // OpenAI - Pro Level
        new ModelDefinition
        {
            Provider = TextGenType.ChatGPT,
            Level = ModelLevel.Pro,
            Name = "GPT-4o",
            Description = "OpenAI's most advanced multimodal model with superior reasoning",
            ModelApiName = "gpt-4o",
            MaxContextTokens = 128000,
            IsVisionSupported = true,
            IsFileUploadSupported = true,
            SupportsJson = true,
            ParametersInBillions = 200,
            InputPricePerMillion = 2.50,
            OutputPricePerMillion = 10.00
        },

        new ModelDefinition
        {
            Provider = TextGenType.ChatGPT,
            Level = ModelLevel.Pro,
            Name = "GPT-4 Turbo",
            Description = "High-capability model with 128K context window",
            ModelApiName = "gpt-4-turbo",
            MaxContextTokens = 128000,
            IsVisionSupported = true,
            IsFileUploadSupported = true,
            SupportsJson = true,
            ParametersInBillions = 1760,
            InputPricePerMillion = 10.00,
            OutputPricePerMillion = 30.00
        },

// OpenAI - Mid Level
        new ModelDefinition
        {
            Provider = TextGenType.ChatGPT,
            Level = ModelLevel.Mid,
            Name = "GPT-4",
            Description = "OpenAI's original GPT-4 model with strong reasoning",
            ModelApiName = "gpt-4",
            MaxContextTokens = 8192,
            IsVisionSupported = false,
            IsFileUploadSupported = false,
            SupportsJson = true,
            ParametersInBillions = 1760,
            InputPricePerMillion = 30.00,
            OutputPricePerMillion = 60.00
        },

// OpenAI - Low Level
        new ModelDefinition
        {
            Provider = TextGenType.ChatGPT,
            Level = ModelLevel.Low,
            Name = "GPT-3.5 Turbo",
            Description = "Fast and efficient model for most tasks",
            ModelApiName = "gpt-3.5-turbo",
            MaxContextTokens = 16384,
            IsVisionSupported = false,
            IsFileUploadSupported = false,
            SupportsJson = true,
            ParametersInBillions = 175,
            InputPricePerMillion = 0.50,
            OutputPricePerMillion = 1.50
        },
    };
}