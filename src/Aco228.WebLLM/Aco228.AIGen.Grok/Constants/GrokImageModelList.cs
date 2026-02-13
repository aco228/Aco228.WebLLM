using Aco228.AIGen.Grok.Models;
using Aco228.AIGen.Models;

namespace Aco228.AIGen.Grok.Constants;

internal static class GrokImageModelList
{
    public static List<ModelImageDefinition> Models = new()
    {
        new(ImageGenProvider.Grok)
        {
            Level = ModelLevel.Pro,
            Name = GrokImageModelType.GrokImagineImagePro.ToString(),
            ModelApiName = ModelTypeHelper.GetModelApiName(GrokImageModelType.GrokImagineImagePro),
            PricePerRequest = 0.07,
        },
        new(ImageGenProvider.Grok)
        {
            Level = ModelLevel.Mid,
            Name = GrokImageModelType.Grok2Image.ToString(),
            ModelApiName = ModelTypeHelper.GetModelApiName(GrokImageModelType.Grok2Image),
            PricePerRequest = 0.07,
        },
        new(ImageGenProvider.Grok)
        {
            Level = ModelLevel.Low,
            Name = GrokImageModelType.GrokImagineImage.ToString(),
            ModelApiName = ModelTypeHelper.GetModelApiName(GrokImageModelType.GrokImagineImage),
            PricePerRequest = 0.02,
        },
    };
}