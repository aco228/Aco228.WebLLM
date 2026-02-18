using Aco228.WService.Attributes;
using Aco228.WService.Base;

namespace Aco228.AIGen.Recraft.Core;

[ApiServiceDecorator(typeof(RecraftServiceConfiguration))]
public interface IRecraftApiService : IApiService
{
    
}