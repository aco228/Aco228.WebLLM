using System.Reflection.Metadata.Ecma335;
using System.Text;
using Aco228.AIGen.Infrastructure;
using Aco228.AIGen.Models;
using Aco228.AIGen.OpenRouter.Services.Web;
using Aco228.Common;
using Aco228.Common.Extensions;

namespace Aco228.AIGen.OpenRouter.Infrastructure;

public static class GenerateOpenRouterModelList
{
    public static async Task Generate()
    {
        var service = ServiceProviderHelper.GetService<IOpenRouterModelsApiService>()!;
        var apiModels = await service.GetModels();

        var sb = new StringBuilder();
        sb.AppendLine("using Aco228.AIGen.Models;\nnamespace Aco228.AIGen.OpenRouter.Constants;");
        sb.AppendLine("internal static class OpenRouterModelList {");
        sb.AppendLine("public static List<ModelDefinition> Models = new() {");
        
        var modelDefinitions = new List<ModelDefinition>();
        foreach (var apiModel in apiModels.data)
        {
            var modelDefinition = new ModelDefinition()
            {
                Provider = TextGenProvider.OpenRouter,
                ModelApiName = apiModel.id,
                Description = apiModel.description,
                Name = apiModel.name,
                ContextWindow = (uint)apiModel.context_length,
                IsVisionSupported = apiModel.architecture.input_modalities.Contains("image"),
                IsImageOutputSupported = apiModel.architecture.output_modalities.Contains("image"),
                InputPricePerMillion = apiModel.pricing.GetPromptPrice() * 1_000_000,
                OutputPricePerMillion = apiModel.pricing.GetOutputPrice() * 1_000_000,
            };
            var avgCost =  modelDefinition.OutputPricePerMillion;
            modelDefinition.PriceLevel = avgCost switch
            {
                < 3 => PriceLevel.Low,
                < 9 => PriceLevel.Mid,
                _ => PriceLevel.High
            };
            modelDefinition.Tier = ModelClassifier.Classify(modelDefinition);
            
            modelDefinitions.Add(modelDefinition);
            AppendModelDefinition(sb, modelDefinition);
        }

        var output = new List<string>();
        foreach (var model in modelDefinitions.OrderByDescending(x => x.PriceLevel))
        {
            output.Add($"{model.ModelApiName},{model.Tier.ToString()},{model.PriceLevel.ToString()}");
        }
        
        var oot = string.Join(Environment.NewLine, output);
        
        sb.AppendLine("}; }");
        var result = sb.ToString();

        int a = 0;

    }

    private static void AppendModelDefinition(StringBuilder sb, ModelDefinition modelDefinition)
    {
        sb.AppendLine("new []() {").Replace("[]", nameof(ModelDefinition));
        AppendParameter(sb, nameof(ModelDefinition.Provider), nameof(TextGenProvider) + ".OpenRouter", false);
        AppendParameter(sb, nameof(ModelDefinition.ModelApiName), modelDefinition.ModelApiName);
        AppendParameter(sb, nameof(ModelDefinition.PriceLevel), nameof(PriceLevel) +  $".{modelDefinition.PriceLevel}", false);
        AppendParameter(sb, nameof(ModelDefinition.Tier), nameof(ModelTier) + $".{modelDefinition.PriceLevel}", false);
        AppendParameter(sb, nameof(ModelDefinition.Name), modelDefinition.Name);
        AppendParameter(sb, nameof(ModelDefinition.ContextWindow), modelDefinition.ContextWindow);
        AppendParameter(sb, nameof(ModelDefinition.IsVisionSupported), modelDefinition.IsVisionSupported);
        AppendParameter(sb, nameof(ModelDefinition.IsImageOutputSupported), modelDefinition.IsImageOutputSupported);
        AppendParameter(sb, nameof(ModelDefinition.InputPricePerMillion), modelDefinition.InputPricePerMillion);
        AppendParameter(sb, nameof(ModelDefinition.OutputPricePerMillion), modelDefinition.OutputPricePerMillion);
        AppendParameter(sb, nameof(ModelDefinition.Description), modelDefinition.Description);
        sb.AppendLine("},");
        sb.AppendLine();
    }

    private static void AppendParameter(StringBuilder sb, string parameterName, object? value, bool addParanthesis = true)
    {
        if (value == null)
            return;
        
        var inputValue = value.ToString();
        if (addParanthesis && value is string)
            inputValue = $"\"{inputValue.Remove("\"").Remove("\r\n").Remove("\n").Remove(Environment.NewLine)}\"";
        if(value is bool)
            inputValue = inputValue.ToLower();
        
        sb.AppendLine($"{parameterName} = {inputValue},");
    }
    
}