using Aco228.AIGen.ChatGPT.Core;
using Aco228.WService.Attributes;
using Aco228.WService.Models.Attributes.MethodAttributes;

namespace Aco228.AIGen.ChatGPT.Services.Web;

[ApiServiceDecorator(typeof(ChatGptApiConfiguration))]
public interface IChatgptModelsApiService : IChatGptApiServiceBase
{
    [ApiGet("v1/models")]
    public Task<string> GetModels();
}