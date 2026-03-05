using Aco228.WService.Attributes;
using Aco228.WService.Base;

namespace Aco228.AIGen.FalAi.Core;

[ApiServiceDecorator(typeof(FalAiServiceConfiguration))]
public interface IFalAiApiService : IApiService
{
    
}