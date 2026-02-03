using Aco228.WService.Attributes;
using Aco228.WService.Base;

namespace Aco228.TextGen.Grok.Code;

[ApiServiceDecorator(typeof(GrokApiConfiguration))]
public interface IGrokApiService : IApiService
{
    
}