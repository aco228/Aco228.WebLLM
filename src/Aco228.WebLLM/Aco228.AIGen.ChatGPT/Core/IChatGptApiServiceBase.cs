using Aco228.WService.Attributes;
using Aco228.WService.Base;

namespace Aco228.AIGen.ChatGPT.Core;

[ApiServiceDecorator(typeof(ChatGptApiConfiguration))]
public interface IChatGptApiServiceBase : IApiService
{
    
}