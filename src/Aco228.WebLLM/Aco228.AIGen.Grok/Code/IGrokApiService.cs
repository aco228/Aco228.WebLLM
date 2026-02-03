using Aco228.WService.Attributes;
using Aco228.WService.Base;

namespace Aco228.AIGen.Grok.Code;

[ApiServiceDecorator(typeof(GrokApiConfiguration))]
public interface IGrokApiService : IApiService
{
    
}