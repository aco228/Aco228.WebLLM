using Aco228.AIGen.Grok.Code;
using Aco228.AIGen.Grok.Models.Images;
using Aco228.WService;

namespace Aco228.AIGen.Grok.Services.Web;

public interface IGrokImageApiService : IGrokApiService
{
    [ApiPost("images/generations")]
    Task<ImageResponse> GenerateImage(ImageRequest request);
}