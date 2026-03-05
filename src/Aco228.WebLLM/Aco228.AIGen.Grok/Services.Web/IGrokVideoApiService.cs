using Aco228.AIGen.Grok.Code;
using Aco228.AIGen.Grok.Models.Video;
using Aco228.WService;
using Aco228.WService.Models.Attributes.MethodAttributes;

namespace Aco228.AIGen.Grok.Services.Web;

public interface IGrokVideoApiService : IGrokApiService
{
    [ApiPost("videos/generations")]
    Task<GrokVideoResponse> RequestVideo(GrokVideoRequest request);

    [ApiGet("videos/{request_id}")]
    Task<GrokVideoStatusResponse> GetVideoStatus(string request_id);
}