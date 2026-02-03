using Aco228.WService.Attributes;
using Aco228.WService.Base;

namespace Aco228.TextGen.Claude.Code;

[ApiServiceDecorator(typeof(ClaudeApiConfiguration))]
public interface IClaudeApiService : IApiService
{
    
}