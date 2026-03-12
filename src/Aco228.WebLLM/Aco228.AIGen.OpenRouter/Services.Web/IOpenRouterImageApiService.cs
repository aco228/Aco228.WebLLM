using Aco228.AIGen.OpenRouter.Core;
using Aco228.AIGen.OpenRouter.Models.Web.Image;
using Aco228.AIGen.OpenRouter.Models.Web.Text;
using Aco228.WService;

namespace Aco228.AIGen.OpenRouter.Services.Web;

/// <summary>
/// 
/// </summary>
public interface IOpenRouterImageApiService : IOpenRouterServiceBase
{
    [ApiPost("responses")]
    Task<OpenRouterImageResponse> GenerateImage(object request);
}