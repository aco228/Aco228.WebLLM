using Aco228.WService.Attributes;
using Aco228.WService.Base;

namespace Aco228.AIGen.Ideogram.Core;

[ApiServiceDecorator(typeof(IdeogramApiConfiguration))]
public interface IIdeogramApiService : IApiService
{
    
}