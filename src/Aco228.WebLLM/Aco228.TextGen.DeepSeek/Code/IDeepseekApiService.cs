using Aco228.WService.Attributes;
using Aco228.WService.Base;

namespace Aco228.TextGen.DeepSeek.Code;

[ApiServiceDecorator(typeof(DeepseekApiConfiguration))]
public interface IDeepseekApiService : IApiService
{
    
}