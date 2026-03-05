using Aco228.AIGen.Gemini.Code;
using Aco228.AIGen.Gemini.Models.Video;
using Aco228.WService;
using Aco228.WService.Attributes;
using Aco228.WService.Base;
using Aco228.WService.Models.Attributes.MethodAttributes;
using Aco228.WService.Models.Attributes.ParameterAttributes;

namespace Aco228.AIGen.Gemini.Services.Web;

[ApiServiceDecorator(typeof(GoogleAiStudioApiConfiguration))]
public interface IGoogleVeoApiService : IApiService
{
    [ApiPost("models/{modelId}:predictLongRunning")]
    Task<VeoGenerateResponse> Generate(string modelId, VideoGenerationRequest request);
    
    [ApiGet("{name}")]
    Task<VeoVideoStatusResponse> GetStatus([ApiToRoute]string name);
}