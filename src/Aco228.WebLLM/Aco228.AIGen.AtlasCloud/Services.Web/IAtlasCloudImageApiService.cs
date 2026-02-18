using Aco228.AIGen.AtlasCloud.Core;
using Aco228.AIGen.AtlasCloud.Models.Images;
using Aco228.WService;
using Aco228.WService.Models.Attributes.MethodAttributes;

namespace Aco228.AIGen.AtlasCloud.Services.Web;

public interface IAtlasCloudImageApiService : IAtlasCloudApiService
{
    [ApiPost("model/generateImage")]
    Task<string> GetString(AtlasCloudImageRequest request);
    
    [ApiPost("model/generateImage")]
    Task<AtlasCloudImageResponse> Get(AtlasCloudImageRequest request);
    
    [ApiGet("model/result/{taskId}")]
    Task<AtlasCloudImageResponse> GetResult(string taskId);
}