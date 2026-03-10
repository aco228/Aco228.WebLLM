using Aco228.WService.Attributes;
using Aco228.WService.Base;

namespace Aco228.AIGen.LeonardoAI.Core;

[ApiServiceDecorator(typeof(LeonardoServiceConfiguration))]
public interface ILeonardoApiService : IApiService
{
    
}