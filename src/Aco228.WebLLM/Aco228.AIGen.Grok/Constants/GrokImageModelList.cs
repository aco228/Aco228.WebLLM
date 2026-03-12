using Aco228.AIGen.Grok.Models;
using Aco228.AIGen.Models;

namespace Aco228.AIGen.Grok.Constants;

internal static class GrokImageModelList
{
    public static List<ModelImageDefinition> Models = new()
    {
        new(ImageGenProvider.Grok)
        {
            PriceLevel = PriceLevel.High,
            Name = GrokImageModelType.GrokImagineImagePro.ToString(),
            ModelApiName = ModelTypeHelper.GetModelApiName(GrokImageModelType.GrokImagineImagePro),
            PricePerRequest = 0.07,
        },
        new(ImageGenProvider.Grok)
        {
            PriceLevel = PriceLevel.Low,
            Name = GrokImageModelType.GrokImagineImage.ToString(),
            ModelApiName = ModelTypeHelper.GetModelApiName(GrokImageModelType.GrokImagineImage),
            PricePerRequest = 0.02,
        },
    };
}