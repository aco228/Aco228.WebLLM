using Aco228.WService.Attributes;
using Aco228.WService.Base;

namespace Aco228.TextGen.Perplexity.Core;

[ApiServiceDecorator(typeof(PerplexityApiConfiguration))]
public interface IPerplexityApiService : IApiService
{
    
}