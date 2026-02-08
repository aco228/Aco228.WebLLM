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
            Level = ModelLevel.Pro,
            Name = ChatGptModelType.GPT5_2.ToString(),
            ModelApiName = ModelTypeHelper.GetModelApiName(ChatGptModelType.GPT5_2),
            InputPricePerMillion = 1.75,
            OutputPricePerMillion = 14.00
        },
        
        new ModelDefinition
        {
            Provider = TextGenProvider.ChatGPT,
            Level = ModelLevel.Mid,
            Name = ChatGptModelType.GPT5_1.ToString(),
            ModelApiName = ModelTypeHelper.GetModelApiName(ChatGptModelType.GPT5_1),
            InputPricePerMillion = 1.25,
            OutputPricePerMillion = 10.00
        },
        
        new ModelDefinition
        {
            Provider = TextGenProvider.ChatGPT,
            Level = ModelLevel.Mid,
            Name = ChatGptModelType.GPT5.ToString(),
            ModelApiName = ModelTypeHelper.GetModelApiName(ChatGptModelType.GPT5),
            InputPricePerMillion = 1.25,
            OutputPricePerMillion = 10.00
        },
        
        new ModelDefinition
        {
            Provider = TextGenProvider.ChatGPT,
            Level = ModelLevel.Low,
            Name = ChatGptModelType.GPT5_MINI.ToString(),
            ModelApiName = ModelTypeHelper.GetModelApiName(ChatGptModelType.GPT5_MINI),
            InputPricePerMillion = 0.25,
            OutputPricePerMillion = 2
        },
        
        new ModelDefinition
        {
            Provider = TextGenProvider.ChatGPT,
            Level = ModelLevel.Low,
            Name = ChatGptModelType.GPT5_NANO.ToString(),
            ModelApiName = ModelTypeHelper.GetModelApiName(ChatGptModelType.GPT5_NANO),
            InputPricePerMillion = 0.05,
            OutputPricePerMillion = 0.4
        },
    };
}