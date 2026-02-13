using System.Collections.Concurrent;
using Aco228.AIGen.Models;
using Aco228.Common;
using Aco228.Common.Models;

namespace Aco228.AIGen.Services;

public interface IImgGenManager : ISingleton
{
    List<ImageGenProvider> Providers { get; }
    List<ModelImageDefinition> ModelDefinitions { get; }
    List<string> Models { get; }
}

public class ImgGenManager : IImgGenManager
{
    private ConcurrentList<ModelImageDefinition> _models = new();
    private ConcurrentDictionary<ImageGenProvider, IImgGen> _generators = new();
    public List<ImageGenProvider> Providers => _models.Select(x => x.Provider).Distinct().ToList();
    public List<ModelImageDefinition> ModelDefinitions => _models.ToList();
    public List<string> Models => _models.Select(x => x.ModelApiName).ToList();
    
    public void RegisterGenerator<T>(ImageGenProvider provider, List<ModelImageDefinition> models)
        where T : IImgGen
    {
        var generator = ServiceProviderHelper.GetServiceByType(typeof(T)) as IImgGen;
        _generators.TryAdd(provider, generator);
        _models.AddRange(models);
    }
}