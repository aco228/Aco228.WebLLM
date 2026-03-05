using Aco228.AIGen.KlingAI.Core;
using Aco228.AIGen.KlingAI.Models.Api;
using Aco228.WService;
using Aco228.WService.Models.Attributes.MethodAttributes;

namespace Aco228.AIGen.KlingAI.Services.Api;

public interface IKlingAiVideoGenerationApiService : IKlingApiService
{
    [ApiPost("videos/text2video")]
    Task<KlingVideoResponse> Generate(KlingVideoRequest request);
    
    [ApiGet("videos/text2video/{task_id}")]
    Task<KlingStatusResponse> GetStatus(string task_id);
}