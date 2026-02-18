using Aco228.WService.Attributes;
using Aco228.WService.Base;

namespace Aco228.AIGen.BlackForestLabs.Core;

[ApiServiceDecorator(typeof(BlackForestLabsApiConfiguration))]
public interface IBlackForestLabsApiService : IApiService
{
    
}