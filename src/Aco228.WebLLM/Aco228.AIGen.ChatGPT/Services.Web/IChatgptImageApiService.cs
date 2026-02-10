using Aco228.AIGen.ChatGPT.Core;
using Aco228.AIGen.ChatGPT.Models.Web.Images;
using Aco228.WService;
using Aco228.WService.Attributes;

namespace Aco228.AIGen.ChatGPT.Services.Web;

/// <summary>
/// https://developers.openai.com/api/reference/resources/images/methods/generate
/// </summary>
[ApiServiceDecorator(typeof(ChatGptApiConfiguration))]
public interface IChatgptImageApiService : IChatGptApiServiceBase
{
    [ApiPost("v1/images/generations")]
    Task<GenerateImageResponse> GenerateImage(GenerateImageRequest request);
}