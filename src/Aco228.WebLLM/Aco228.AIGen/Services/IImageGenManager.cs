using System.Collections.Concurrent;
using Aco228.AIGen.Models;
using Aco228.Common;
using Aco228.Common.Extensions;
using Aco228.Common.Infrastructure;
using Aco228.Common.Models;

namespace Aco228.AIGen.Services;

public interface IImageGenManager : ISingleton
{
    List<ImageGenProvider> Providers { get; }
    List<ModelImageDefinition> ModelDefinitions { get; }
    List<string> Models { get; }
    HttpClient GetHttpClientFrom(ImageGenProvider provider);
    ModelImageDefinition? GetModelDefinition(Enum apiName);
    ManagedList<ModelImageDefinition> FilterModelsBySpecification(ImageGenerateSpecifications specifications);
    Task<List<GenerateImageResponse>> Generate(GenerateImageRequest prompt);
    Task<GenerateImageResponse?> GetResultFor(ImageGenProvider provider, string taskId);
}

public class ImageGenManager : IImageGenManager
{
    private ConcurrentList<ModelImageDefinition> _models = new();
    private ConcurrentDictionary<ImageGenProvider, IImageGen> _generators = new();
    public List<ImageGenProvider> Providers => _models.Select(x => x.Provider).Distinct().ToList();
    public List<ModelImageDefinition> ModelDefinitions => _models.ToList();
    public List<string> Models => _models.Select(x => x.ModelApiName).ToList();

    public HttpClient GetHttpClientFrom(ImageGenProvider provider)
    {
        return _generators[provider].GetHttpClient();
    }

    public ModelImageDefinition? GetModelDefinition(Enum apiName)
    {
        var modelname = ModelTypeHelper.GetModelApiName(apiName);
        return _models.FirstOrDefault(x => x.ModelApiName == modelname);
    }
    
    public void RegisterGenerator<T>(ImageGenProvider provider, List<ModelImageDefinition> models)
        where T : IImageGen
    {
        var generator = ServiceProviderHelper.GetServiceByType(typeof(T)) as IImageGen;
        if(generator == null)
            throw new Exception("Generator not found");
        
        _generators.TryAdd(provider, generator);
        _models.AddRange(models);
    }

    public ManagedList<ModelImageDefinition> FilterModelsBySpecification(ImageGenerateSpecifications specifications)
    {
        var models = _models
            .Where(x => x.PriceLevel == specifications.ModelPriceLevel)
            .Where(x => specifications.Providers.Any() == false || specifications.Providers.Contains(x.Provider));

        return models.Shuffle().ToManagedList();
    }

    public async Task<List<GenerateImageResponse>> Generate(GenerateImageRequest prompt)
    {
        ModelImageDefinition? modelDefinition = _models
            .Where(x => string.IsNullOrEmpty(prompt.ModelName) || x.ModelApiName == prompt.ModelName)
            .Where(x => prompt.Provider == null || x.Provider == prompt.Provider)
            .Where(x => prompt.PriceLevel == null || x.PriceLevel == prompt.PriceLevel)
            .Where(x => prompt.Tier == null || x.Tier == prompt.Tier)
            .Shuffle()
            .FirstOrDefault();
        
        if(modelDefinition == null)
            throw new Exception("No suitable model found");
        
        if(!_generators.TryGetValue(modelDefinition.Provider, out var generator))
            throw new Exception("No generator available for model " + modelDefinition.ModelApiName);
        
        if(string.IsNullOrEmpty(prompt.ModelName))
            prompt.ModelName = modelDefinition.ModelApiName; 
        
        return await generator.Generate(prompt);       
    }

    public async Task<GenerateImageResponse?> GetResultFor(ImageGenProvider provider, string taskId)
    {
        if(!_generators.TryGetValue(provider, out var generator))
            throw new Exception("No generator available for model " + provider.ToString());
        
        var result = await generator.GetResultFor(taskId);
        return result;
    }
}