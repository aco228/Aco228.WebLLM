using System.Collections.Concurrent;
using Aco228.AIGen.Models;
using Aco228.Common;
using Aco228.Common.Extensions;
using Aco228.Common.Infrastructure;
using Aco228.Common.Models;

namespace Aco228.AIGen.Services;

public interface IImgGenManager : ISingleton
{
    List<ImageGenProvider> Providers { get; }
    List<ModelImageDefinition> ModelDefinitions { get; }
    List<string> Models { get; }
    ModelImageDefinition? GetModelDefinition(Enum apiName);
    ManagedList<ModelImageDefinition> FilterSuitableModels(List<ImageGenProvider> providers, List<string> modelNames);
    Task<List<GenerateImageResponse>> Generate(GenerateImageRequest prompt);
}

public class ImgGenManager : IImgGenManager
{
    private ConcurrentList<ModelImageDefinition> _models = new();
    private ConcurrentDictionary<ImageGenProvider, IImgGen> _generators = new();
    public List<ImageGenProvider> Providers => _models.Select(x => x.Provider).Distinct().ToList();
    public List<ModelImageDefinition> ModelDefinitions => _models.ToList();
    public List<string> Models => _models.Select(x => x.ModelApiName).ToList();
    
    public ModelImageDefinition? GetModelDefinition(Enum apiName)
    {
        var modelname = ModelTypeHelper.GetModelApiName(apiName);
        return _models.FirstOrDefault(x => x.ModelApiName == modelname);
    }
    
    public void RegisterGenerator<T>(ImageGenProvider provider, List<ModelImageDefinition> models)
        where T : IImgGen
    {
        var generator = ServiceProviderHelper.GetServiceByType(typeof(T)) as IImgGen;
        _generators.TryAdd(provider, generator);
        _models.AddRange(models);
    }
    
    public ManagedList<ModelImageDefinition> FilterSuitableModels(List<ImageGenProvider> providers, List<string> modelNames)
    {
        return _models
            .Where(x => providers.Contains(x.Provider))
            .Where(x => modelNames.Contains(x.ModelApiName))
            .ToManagedList();
    }

    public async Task<List<GenerateImageResponse>> Generate(GenerateImageRequest prompt)
    {
        ModelImageDefinition? modelDefinition = null;
        if(!string.IsNullOrEmpty(prompt.ModelName))
            modelDefinition = _models.FirstOrDefault(x => x.ModelApiName == prompt.ModelName);
        else if(prompt.Provider != null)
            modelDefinition = _models.Shuffle().FirstOrDefault(x => x.Provider == prompt.Provider);
        else
            modelDefinition = _models.Shuffle().First();
        
        if(modelDefinition == null)
            throw new Exception("No suitable model found");
        
        var generator = _generators[modelDefinition.Provider];
        return await generator.Generate(prompt);       
    }
}