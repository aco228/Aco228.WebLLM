using Aco228.AIGen.PoyoAI.Core;
using Aco228.AIGen.PoyoAI.Models.Images;
using Aco228.WService;
using Aco228.WService.Attributes;
using Aco228.WService.Base;
using Aco228.WService.Models.Attributes.MethodAttributes;

namespace Aco228.AIGen.PoyoAI.Api;

[ApiServiceDecorator(typeof(PoyoApiServiceConfiguration))]
public interface IPoyoApiService : IApiService
{
    [ApiPost("generate/submit")]
    public Task<ImageResponse> GenerateImage(ImageRequest request);
    
    [ApiGet("generate/status/{task_id}")]
    public Task<ImageResponse> GetStatus(string task_id);
}