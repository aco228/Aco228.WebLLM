using Aco228.AIGen.Ideogram.Core;
using Aco228.AIGen.Ideogram.Models.Image;
using Aco228.WService;

namespace Aco228.AIGen.Ideogram.Services.Web;

/// <summary>
/// https://developer.ideogram.ai/api-reference/api-reference/generate-v3
/// </summary>
public interface IIdeogramImageApiService : IIdeogramApiService
{
    [ApiPost("ideogram-v3/generate")]
    public Task<string> GetString(IdeogramImageRequest request);
    
    [ApiPost("ideogram-v3/generate")]
    public Task<IdeogramImageResponse> Get(IdeogramImageRequest request);
}