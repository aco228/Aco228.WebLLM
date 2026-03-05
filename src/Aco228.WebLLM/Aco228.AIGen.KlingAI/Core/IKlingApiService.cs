using Aco228.WService.Attributes;
using Aco228.WService.Base;

namespace Aco228.AIGen.KlingAI.Core;

[ApiServiceDecorator(typeof(KlingApiConfiguration))]
public interface IKlingApiService : IApiService
{
    
}