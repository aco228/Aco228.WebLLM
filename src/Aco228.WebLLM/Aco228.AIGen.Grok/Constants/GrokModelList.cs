using Aco228.AIGen.Grok.Models;
using Aco228.AIGen.Models;

namespace Aco228.AIGen.Grok.Constants;

internal static class GrokModelList
{
    public static List<ModelDefinition> Models = new()
    {
        new ModelDefinition
        {
            Provider = TextGenProvider.Grok,
            PriceLevel = PriceLevel.High,
            Name = "Grok 4Pro",
            ModelApiName = ModelTypeHelper.GetModelApiName(GrokModelType.Grok4Pro),
            InputPricePerMillion = 3.00,
            OutputPricePerMillion = 15.00,
            Tier = ModelTier.High,
            IsVisionSupported = true,
            IsImageOutputSupported = false
        },

        new ModelDefinition
        {
            Provider = TextGenProvider.Grok,
            PriceLevel = PriceLevel.Low,
            Name = "Grok 4.1 Fast NonReasoning",
            ModelApiName = ModelTypeHelper.GetModelApiName(GrokModelType.Grok4_1FastNonReasoning),
            InputPricePerMillion = 0.20,
            OutputPricePerMillion = 0.50,
            Tier = ModelTier.High,
            IsVisionSupported = true,
            IsImageOutputSupported = false
        },

        new ModelDefinition
        {
            Provider = TextGenProvider.Grok,
            PriceLevel = PriceLevel.Low,
            Name = "Grok CodeFast",
            ModelApiName = ModelTypeHelper.GetModelApiName(GrokModelType.GrokCodeFast1),
            InputPricePerMillion = 0.20,
            OutputPricePerMillion = 1.50,
            Tier = ModelTier.Low,
            IsVisionSupported = false,
            IsImageOutputSupported = false
        },

        new ModelDefinition
        {
            Provider = TextGenProvider.Grok,
            PriceLevel = PriceLevel.Low,
            Name = "Grok 3 Mini",
            ModelApiName = ModelTypeHelper.GetModelApiName(GrokModelType.Grok3Mini),
            InputPricePerMillion = 0.30,
            OutputPricePerMillion = 0.50,
            Tier = ModelTier.Mid,
            IsVisionSupported = false,
            IsImageOutputSupported = false
        },
    };
}