using Aco228.WService.Attributes;
using Aco228.WService.Base;

namespace Aco228.AIGen.OpenRouter.Core;

[ApiServiceDecorator(typeof(OpenRouterApiConfiguration))]
public interface IOpenRouterServiceBase : IApiService
{
    
}