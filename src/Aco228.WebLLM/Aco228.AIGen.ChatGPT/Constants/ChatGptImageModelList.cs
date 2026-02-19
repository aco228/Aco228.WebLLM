using Aco228.AIGen.ChatGPT.Models;
using Aco228.AIGen.Models;

namespace Aco228.AIGen.ChatGPT.Constants;

internal static class ChatGptImageModelList
{
    public static List<ModelImageDefinition> Models = new()
    {
        new(ImageGenProvider.OpenAI)
        {
            PriceLevel = PriceLevel.High,
            Name = ChatGptImageModelType.gpt_image_1_5.ToString(),
            ModelApiName = ModelTypeHelper.GetModelApiName(ChatGptImageModelType.gpt_image_1_5),
            PricePerRequest = 0.05,
        },
        
        new(ImageGenProvider.OpenAI)
        {
            PriceLevel = PriceLevel.Mid,
            Name = ChatGptImageModelType.gpt_image_1.ToString(),
            ModelApiName = ModelTypeHelper.GetModelApiName(ChatGptImageModelType.gpt_image_1),
            PricePerRequest = 0.04,
        },
        
        new(ImageGenProvider.OpenAI)
        {
            PriceLevel = PriceLevel.Low,
            Name = ChatGptImageModelType.gpt_image_1_mini.ToString(),
            ModelApiName = ModelTypeHelper.GetModelApiName(ChatGptImageModelType.gpt_image_1_mini),
            PricePerRequest = 0.01,
        },
        
    };
}