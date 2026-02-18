using Aco228.WService.Attributes;
using Aco228.WService.Base;

namespace Aco228.AIGen.Minimax.Core;

[ApiServiceDecorator(typeof(MinimaxApiConfiguration))]
public interface IMinimaxApiService : IApiService
{
    
}