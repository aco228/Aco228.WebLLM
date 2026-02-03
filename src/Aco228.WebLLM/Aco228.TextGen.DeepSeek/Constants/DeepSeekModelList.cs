using Aco228.AIGen.Models;

namespace Aco228.TextGen.DeepSeek.Constants;

internal static class DeepSeekModelList
{
    public static List<ModelDefinition> Models = new()
    {
        // DeepSeek - Pro Level
        new ModelDefinition
        {
            Provider = TextGenType.DeepSeek,
            Level = ModelLevel.Mid,
            Name = "DeepSeek V3.2",
            Description = "DeepSeek's most advanced model",
            ModelApiName = "deepseek-chat",
            MaxContextTokens = 64000,
            IsVisionSupported = false,
            IsFileUploadSupported = false,
            SupportsJson = true,
            ParametersInBillions = 671,
            InputPricePerMillion = 0.28,
            OutputPricePerMillion = 0.42
        },
        
        // DeepSeek - Pro Level
        new ModelDefinition
        {
            Provider = TextGenType.DeepSeek,
            Level = ModelLevel.Pro,
            Name = "DeepSeek V3.2 (Thinking Mode)",
            Description = "DeepSeek's most advanced reasoning model",
            ModelApiName = "deepseek-reasoner",
            MaxContextTokens = 64000,
            IsVisionSupported = false,
            IsFileUploadSupported = false,
            SupportsJson = true,
            ParametersInBillions = 671,
            InputPricePerMillion = 0.28,
            OutputPricePerMillion = 0.42
        },
    };
}