using Aco228.AIGen.DeepAI.Core;
using Aco228.AIGen.DeepAI.Models.Web.CreateImage;
using Aco228.WService;

namespace Aco228.AIGen.DeepAI.Services.Web;

public interface IDeepAiImageGeneratorApiService : DeepAiApiService
{
    [ApiPost("text2img")]
    Task<DeepAiCreateImageResponse> GenerateImage(DeepAiCreateImageRequest request);
    
    [ApiPost("text2img")]
    Task<string> GenerateImageString(DeepAiCreateImageRequest request);
}