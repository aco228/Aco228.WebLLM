using Aco228.AIGen.FalAi.Core;
using Aco228.AIGen.FalAi.Models.Web;
using Aco228.WService;
using Aco228.WService.Models.Attributes.ParameterAttributes;

namespace Aco228.AIGen.FalAi.Services.Api;

public interface IFalAiTextToImageApiService : IFalAiApiService
{
    [ApiPost("fal-ai/{modelName}")]
    public Task<FalAiImageResponse> RequestImage([ApiToRoute] string modelName, FalImageRequest request);
}