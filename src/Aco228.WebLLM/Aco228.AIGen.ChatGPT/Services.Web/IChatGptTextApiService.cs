using Aco228.AIGen.ChatGPT.Core;
using Aco228.AIGen.ChatGPT.Models.Web.Request;
using Aco228.AIGen.ChatGPT.Models.Web.Response;
using Aco228.Common.Models;
using Aco228.WService;

namespace Aco228.AIGen.ChatGPT.Services.Web;

/// <summary>
/// https://platform.openai.com/docs/api-reference/responses/create?lang=curl
/// </summary>
public interface IChatGptTextApiService : IChatGptApiServiceBase
{
    [ApiPost("v1/responses")]
    Task<CreateTextResponse> GetResponse(CreateTextRequest request);
}