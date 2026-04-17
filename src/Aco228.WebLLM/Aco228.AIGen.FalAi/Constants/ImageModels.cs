using Aco228.AIGen.FalAi.Models;
using Aco228.AIGen.Models;

namespace Aco228.AIGen.FalAi.Constants;

internal static class ImageModels
{
    public static List<ModelImageDefinition> Models = new()
    {
        new()
        {
            Provider = ImageGenProvider.FalAi,
            ModelApiName = ModelTypeHelper.GetModelApiName(FalAiImageType.Seadream5_lite),
            PriceLevel = PriceLevel.High,
            Tier = ModelTier.High,
            Name = FalAiImageType.Seadream5_lite.ToString(),
            PricePerRequest = 0,
        },
        new()
        {
            Provider = ImageGenProvider.FalAi,
            ModelApiName = ModelTypeHelper.GetModelApiName(FalAiImageType.Seadream4_5),
            PriceLevel = PriceLevel.High,
            Tier = ModelTier.High,
            Name = FalAiImageType.Seadream4_5.ToString(),
            PricePerRequest = 0,
        },
        new()
        {
            Provider = ImageGenProvider.FalAi,
            ModelApiName = ModelTypeHelper.GetModelApiName(FalAiImageType.ZImageTurbo),
            PriceLevel = PriceLevel.High,
            Tier = ModelTier.High,
            Name = FalAiImageType.ZImageTurbo.ToString(),
            PricePerRequest = 0,
        },
        new()
        {
            Provider = ImageGenProvider.FalAi,
            ModelApiName = ModelTypeHelper.GetModelApiName(FalAiImageType.ZImageTurbo),
            PriceLevel = PriceLevel.High,
            Tier = ModelTier.High,
            Name = FalAiImageType.ZImageTurbo.ToString(),
            PricePerRequest = 0,
        },
        new()
        {
            Provider = ImageGenProvider.FalAi,
            ModelApiName = ModelTypeHelper.GetModelApiName(FalAiImageType.QwenImage2Pro),
            PriceLevel = PriceLevel.High,
            Tier = ModelTier.High,
            Name = FalAiImageType.QwenImage2Pro.ToString(),
            PricePerRequest = 0.07,
        },
        new()
        {
            Provider = ImageGenProvider.FalAi,
            ModelApiName = ModelTypeHelper.GetModelApiName(FalAiImageType.Flux2Pro),
            PriceLevel = PriceLevel.High,
            Tier = ModelTier.High,
            Name = FalAiImageType.Flux2Pro.ToString(),
            PricePerRequest = 0,
        },
        new()
        {
            Provider = ImageGenProvider.FalAi,
            ModelApiName = ModelTypeHelper.GetModelApiName(FalAiImageType.FluxSchnell),
            PriceLevel = PriceLevel.High,
            Tier = ModelTier.High,
            Name = FalAiImageType.FluxSchnell.ToString(),
            PricePerRequest = 0.03,
        },
        new()
        {
            Provider = ImageGenProvider.FalAi,
            ModelApiName = ModelTypeHelper.GetModelApiName(FalAiImageType.FluxDev),
            PriceLevel = PriceLevel.High,
            Tier = ModelTier.High,
            Name = FalAiImageType.FluxDev.ToString(),
            PricePerRequest = 0.03,
        },
        new()
        {
            Provider = ImageGenProvider.FalAi,
            ModelApiName = ModelTypeHelper.GetModelApiName(FalAiImageType.Flux2Turbo),
            PriceLevel = PriceLevel.High,
            Tier = ModelTier.High,
            Name = FalAiImageType.Flux2Turbo.ToString(),
            PricePerRequest = 0.03,
        },
        new()
        {
            Provider = ImageGenProvider.FalAi,
            ModelApiName = ModelTypeHelper.GetModelApiName(FalAiImageType.Flux2Max),
            PriceLevel = PriceLevel.High,
            Tier = ModelTier.High,
            Name = FalAiImageType.Flux2Max.ToString(),
            PricePerRequest = 0.03,
        },
        new()
        {
            Provider = ImageGenProvider.FalAi,
            ModelApiName = ModelTypeHelper.GetModelApiName(FalAiImageType.Phota),
            PriceLevel = PriceLevel.High,
            Tier = ModelTier.High,
            Name = FalAiImageType.Phota.ToString(),
            PricePerRequest = 0.09,
        },
        new()
        {
            Provider = ImageGenProvider.FalAi,
            ModelApiName = ModelTypeHelper.GetModelApiName(FalAiImageType.WanPro),
            PriceLevel = PriceLevel.High,
            Tier = ModelTier.High,
            Name = FalAiImageType.WanPro.ToString(),
            PricePerRequest = 0.07,
        },
        new()
        {
            Provider = ImageGenProvider.FalAi,
            ModelApiName = ModelTypeHelper.GetModelApiName(FalAiImageType.Wan),
            PriceLevel = PriceLevel.High,
            Tier = ModelTier.High,
            Name = FalAiImageType.Wan.ToString(),
            PricePerRequest = 0.03,
        },
        new()
        {
            Provider = ImageGenProvider.FalAi,
            ModelApiName = ModelTypeHelper.GetModelApiName(FalAiImageType.LuminaImage),
            PriceLevel = PriceLevel.High,
            Tier = ModelTier.High,
            Name = FalAiImageType.LuminaImage.ToString(),
            PricePerRequest = 0.075,
        },
        new()
        {
            Provider = ImageGenProvider.FalAi,
            ModelApiName = ModelTypeHelper.GetModelApiName(FalAiImageType.ErnieTurbo),
            PriceLevel = PriceLevel.High,
            Tier = ModelTier.High,
            Name = FalAiImageType.ErnieTurbo.ToString(),
            PricePerRequest = 0.01,
        },
        new()
        {
            Provider = ImageGenProvider.FalAi,
            ModelApiName = ModelTypeHelper.GetModelApiName(FalAiImageType.Ernie),
            PriceLevel = PriceLevel.High,
            Tier = ModelTier.High,
            Name = FalAiImageType.Ernie.ToString(),
            PricePerRequest = 0.01,
        },
        new()
        {
            Provider = ImageGenProvider.FalAi,
            ModelApiName = ModelTypeHelper.GetModelApiName(FalAiImageType.NucleusImage),
            PriceLevel = PriceLevel.High,
            Tier = ModelTier.High,
            Name = FalAiImageType.NucleusImage.ToString(),
            PricePerRequest = 0.01,
        },
        new()
        {
            Provider = ImageGenProvider.FalAi,
            ModelApiName = ModelTypeHelper.GetModelApiName(FalAiImageType.OvisImage),
            PriceLevel = PriceLevel.High,
            Tier = ModelTier.High,
            Name = FalAiImageType.OvisImage.ToString(),
            PricePerRequest = 0.012,
        },
        new()
        {
            Provider = ImageGenProvider.FalAi,
            ModelApiName = ModelTypeHelper.GetModelApiName(FalAiImageType.ImagineArt),
            PriceLevel = PriceLevel.High,
            Tier = ModelTier.High,
            Name = FalAiImageType.ImagineArt.ToString(),
            PricePerRequest = 0.03,
        },
    };
}