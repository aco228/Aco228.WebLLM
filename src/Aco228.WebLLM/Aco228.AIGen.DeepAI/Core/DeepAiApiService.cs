using Aco228.WService.Attributes;
using Aco228.WService.Base;

namespace Aco228.AIGen.DeepAI.Core;

[ApiServiceDecorator(typeof(DeepAiApiConfiguration))]
public interface DeepAiApiService : IApiService 
{
    
}