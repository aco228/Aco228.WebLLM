using Aco228.AIGen.Models;
using Aco228.Common;
using Aco228.Common.Extensions;
using Aco228.Common.Infrastructure;
using Aco228.Common.Models;

namespace Aco228.AIGen.Services;

public interface ITextGenManager : ISingleton
{
    List<ModelDefinition> ModelDefinitions { get; }
    List<TextGenProvider> Providers { get; }
    Task<string> GetText(TextGenerationRequest request);
    Task<TextGenResponse> GetResponse(TextGenerationRequest request);
    ModelDefinition? GetModelDefinition(Enum modelType);
}

public class TextGenManager : ITextGenManager
{
    ManagedList<ITextGen> _textGens = new();
    public List<ModelDefinition> ModelDefinitions { get; private set; } = new();
    public List<TextGenProvider> Providers => ModelDefinitions.Select(x => x.Provider).Distinct().ToList();

    public async Task<TextGenResponse> GetResponse(TextGenerationRequest request)
    {
        if(string.IsNullOrEmpty(request.User) && string.IsNullOrEmpty(request.System))
            throw new Exception("User or system prompt is required");
        
        ITextGen textGen = GetTextGeneratorFromRequest(request);
        var modelDefinitions = GetModelDefinitionFromRequest(request, textGen);

        for (int i = 0; i < 5; i++)
        {
            try
            {
                var modelDefinition = modelDefinitions.Take();
                var textGenRequest = new TextGenRequest()
                {
                    Model = modelDefinition,
                    User = request.User,
                    System = request.System,
                    ImageUrls = request.ImageUrls,
                };

                var textGenResponse = await textGen.Generate(textGenRequest);
                if (textGenResponse == null || string.IsNullOrEmpty(textGenResponse.Response))
                    throw new Exception("No response from text gen");

                textGenResponse.InputCost = (textGenResponse.InputTokens / 1_000_000.0) * modelDefinition.InputPricePerMillion;
                textGenResponse.OuputCost = (textGenResponse.OutputTokens / 1_000_000.0) * modelDefinition.OutputPricePerMillion;

                // using var liteFile = new LiteFile<TextGenResponse>("textGen");
                // liteFile.Insert(textGenResponse);

                return textGenResponse;
            }
            catch (Exception ex)
            {
                if (modelDefinitions.Count == 1)
                    break;
                
                await Task.Delay(100);
            }
        }

        return null;
    }

    private ManagedList<ModelDefinition> GetModelDefinitionFromRequest(TextGenerationRequest request, ITextGen textGen)
    {
        var modelDefinition = ModelDefinitions
            .Where(x => x.Provider == textGen.Provider)
            .Where(x => string.IsNullOrEmpty(request.ModelName) || x.ModelApiName.Equals(request.ModelName))
            .Where(x => request.PriceLevel is null || x.PriceLevel == request.PriceLevel)
            .Where(x => request.TierLevel is null || x.Tier == request.TierLevel)
            .Shuffle()
            .ToManagedList();
        
        if (modelDefinition == null || modelDefinition.Any() == false)
            throw new Exception("No model available");
        
        return modelDefinition;
    }

    private ITextGen GetTextGeneratorFromRequest(TextGenerationRequest request)
    {
        ITextGen? textGen = _textGens
            .Where(x => request.Provider == null || x.Provider == request.Provider)
            .Where(x => request.Model == null || x.Models.Any(y => y.ModelApiName == request.ModelName))
            .Shuffle()
            .FirstOrDefault();
        
        if(textGen == null)
            textGen = _textGens.Take();
        
        if(textGen == null) 
            throw new Exception("No text gen available");
        
        return textGen;
    }

    public ModelDefinition? GetModelDefinition(Enum modelType)
    {
        var modelName = ModelTypeHelper.GetModelApiName(modelType);
        return _textGens.SelectMany(x => x.Models).FirstOrDefault(x => x.ModelApiName == modelName);
    }

    public async Task<string> GetText(TextGenerationRequest request)
    {
        var response = await GetResponse(request);
        return response.Response;
    }
    
    public void Register<T>(TextGenProvider provider, List<ModelDefinition> models) where T : ITextGen
    {
        var service = ServiceProviderHelper.GetServiceByType(typeof(T)) as ITextGen;
        if (service == null)
        {
            Console.WriteLine($">>>> ERROR: Text generator `{provider}` not found");
            return;
        }
        _textGens.Add(service!);
        ModelDefinitions.AddRange(models);
    }
}