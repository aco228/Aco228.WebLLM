using Aco228.AIGen.OpenRouter.Core;
using Aco228.AIGen.OpenRouter.Models.Web.Text;
using Aco228.WService;

namespace Aco228.AIGen.OpenRouter.Services.Web;

/// <summary>
/// 
/// </summary>
public interface IOpenRouterTextApiService : IOpenRouterServiceBase
{
    [ApiPost("responses")]
    Task<string> GenerateTextString(OpenRouterTextRequest request);
    
    [ApiPost("responses")]
    Task<OpenRouterTextResponse> GenerateText(OpenRouterTextRequest request);
}