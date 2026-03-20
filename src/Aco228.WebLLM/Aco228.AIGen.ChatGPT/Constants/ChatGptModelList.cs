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
            Name = ChatGptModelType.GptPro.ToString(),
            ModelApiName = ModelTypeHelper.GetModelApiName(ChatGptModelType.GptPro),
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
            Name = ChatGptModelType.GptMini.ToString(),
            ModelApiName = ModelTypeHelper.GetModelApiName(ChatGptModelType.GptMini),
            InputPricePerMillion = 0.75,
            OutputPricePerMillion = 4.5,
            Tier = ModelTier.Mid,
            IsVisionSupported = true,
            IsImageOutputSupported = false
        },
        
        new ModelDefinition
        {
            Provider = TextGenProvider.ChatGPT,
            PriceLevel = PriceLevel.Low,
            Name = ChatGptModelType.GptNano.ToString(),
            ModelApiName = ModelTypeHelper.GetModelApiName(ChatGptModelType.GptNano),
            InputPricePerMillion = 0.2,
            OutputPricePerMillion = 1.25,
            Tier = ModelTier.Mid,
            IsVisionSupported = true,
            IsImageOutputSupported = false
        },
        
    };
}