using Aco228.AIGen.Models;
using Aco228.AIGen.PoyoAI.Models;

namespace Aco228.AIGen.PoyoAI.Constants;

public static class PoyoImages
{
    public static List<ModelImageDefinition> Models => new()
    {
        new()
        {
            Level = ModelLevel.Mid,
            Provider = ImageGenProvider.Poyo,
            Name = PoyoModelType.gpt4o.ToString(),
            ModelApiName = ModelTypeHelper.GetModelApiName(PoyoModelType.gpt4o),
            PricePerRequest = 0.02,
        },
        new()
        {
            Level = ModelLevel.Mid,
            Provider = ImageGenProvider.Poyo,
            Name = PoyoModelType.gpt1_5.ToString(),
            ModelApiName = ModelTypeHelper.GetModelApiName(PoyoModelType.gpt1_5),
            PricePerRequest = 0.01,
        },
        new()
        {
            Level = ModelLevel.Mid,
            Provider = ImageGenProvider.Poyo,
            Name = PoyoModelType.GrokImage.ToString(),
            ModelApiName = ModelTypeHelper.GetModelApiName(PoyoModelType.GrokImage),
            PricePerRequest = 0.03,
        },
        new()
        {
            Level = ModelLevel.Mid,
            Provider = ImageGenProvider.Poyo,
            Name = PoyoModelType.ZImage.ToString(),
            ModelApiName = ModelTypeHelper.GetModelApiName(PoyoModelType.ZImage),
            PricePerRequest = 0.01,
        },
        new()
        {
            Level = ModelLevel.Mid,
            Provider = ImageGenProvider.Poyo,
            Name = PoyoModelType.Seadream4_5.ToString(),
            ModelApiName = ModelTypeHelper.GetModelApiName(PoyoModelType.Seadream4_5),
            PricePerRequest = 0.025,
        },
        new()
        {
            Level = ModelLevel.Mid,
            Provider = ImageGenProvider.Poyo,
            Name = PoyoModelType.Flux2Pro.ToString(),
            ModelApiName = ModelTypeHelper.GetModelApiName(PoyoModelType.Flux2Pro),
            PricePerRequest = 0.03,
        },
        new()
        {
            Level = ModelLevel.Mid,
            Provider = ImageGenProvider.Poyo,
            Name = PoyoModelType.Flux2Flex.ToString(),
            ModelApiName = ModelTypeHelper.GetModelApiName(PoyoModelType.Flux2Flex),
            PricePerRequest = 0.025,
        },
        new()
        {
            Level = ModelLevel.Mid,
            Provider = ImageGenProvider.Poyo,
            Name = PoyoModelType.NanoBanana2.ToString(),
            ModelApiName = ModelTypeHelper.GetModelApiName(PoyoModelType.NanoBanana2),
            PricePerRequest = 0.03,
        },
        new()
        {
            Level = ModelLevel.Mid,
            Provider = ImageGenProvider.Poyo,
            Name = PoyoModelType.NanoBanana.ToString(),
            ModelApiName = ModelTypeHelper.GetModelApiName(PoyoModelType.NanoBanana),
            PricePerRequest = 0.025,
        }
    };
}