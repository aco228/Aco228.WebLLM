using Aco228.AIGen.ChatGPT.Models;
using Aco228.AIGen.Models;

namespace Aco228.AIGen.ChatGPT.Constants;

internal static class ChatGptModelList
{
    public static List<ModelDefinition> Models = new()
    {
        new ModelDefinition
        {
            Provider = TextGenProvider.ChatGPT,
            PriceLevel = PriceLevel.High,
            Name = ChatGptModelType.GPT5_2.ToString(),
            ModelApiName = ModelTypeHelper.GetModelApiName(ChatGptModelType.GPT5_2),
            InputPricePerMillion = 1.75,
            OutputPricePerMillion = 14.00,
            Tier = ModelTier.High,
            IsVisionSupported = true,
            IsImageOutputSupported = false
        },
        
        new ModelDefinition
        {
            Provider = TextGenProvider.ChatGPT,
            PriceLevel = PriceLevel.High,
            Name = ChatGptModelType.GPT5_1.ToString(),
            ModelApiName = ModelTypeHelper.GetModelApiName(ChatGptModelType.GPT5_1),
            InputPricePerMillion = 1.25,
            OutputPricePerMillion = 10.00,
            Tier = ModelTier.High,
            IsVisionSupported = true,
            IsImageOutputSupported = false
        },
        
        new ModelDefinition
        {
            Provider = TextGenProvider.ChatGPT,
            PriceLevel = PriceLevel.Mid,
            Name = ChatGptModelType.GPT5.ToString(),
            ModelApiName = ModelTypeHelper.GetModelApiName(ChatGptModelType.GPT5),
            InputPricePerMillion = 1.25,
            OutputPricePerMillion = 10.00,
            Tier = ModelTier.High,
            IsVisionSupported = true,
            IsImageOutputSupported = false
        },
        
        new ModelDefinition
        {
            Provider = TextGenProvider.ChatGPT,
            PriceLevel = PriceLevel.Low,
            Name = ChatGptModelType.GPT5_MINI.ToString(),
            ModelApiName = ModelTypeHelper.GetModelApiName(ChatGptModelType.GPT5_MINI),
            InputPricePerMillion = 0.25,
            OutputPricePerMillion = 2,
            Tier = ModelTier.Mid,
            IsVisionSupported = false,
            IsImageOutputSupported = false
        },
        
        new ModelDefinition
        {
            Provider = TextGenProvider.ChatGPT,
            PriceLevel = PriceLevel.Low,
            Name = ChatGptModelType.GPT5_NANO.ToString(),
            ModelApiName = ModelTypeHelper.GetModelApiName(ChatGptModelType.GPT5_NANO),
            InputPricePerMillion = 0.05,
            OutputPricePerMillion = 0.4,
            Tier = ModelTier.Low,
            IsVisionSupported = false,
            IsImageOutputSupported = false
        },
    };
}