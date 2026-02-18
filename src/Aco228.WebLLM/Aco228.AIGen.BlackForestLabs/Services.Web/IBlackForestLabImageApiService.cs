using Aco228.AIGen.BlackForestLabs.Core;
using Aco228.AIGen.BlackForestLabs.Models.Images;
using Aco228.WService;
using Aco228.WService.Models.Attributes.MethodAttributes;
using Aco228.WService.Models.Attributes.ParameterAttributes;

namespace Aco228.AIGen.BlackForestLabs.Services.Web;

public interface IBlackForestLabImageApiService : IBlackForestLabsApiService
{
    [ApiPost("{modelName}")]
    Task<BlackForestLabsImageResponse> Get(string modelName, BlackForestLabsImageRequest request);
    
    [ApiGet("get_result?id={id}")]
    Task<BlackForestLabsResultResponse> GetResult(string id);
    
    [ApiGet("get_result?id={id}")]
    Task<string> GetResultString(string id);
}