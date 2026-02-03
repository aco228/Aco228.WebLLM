using Aco228.TextGen.Grok.Code;
using Aco228.TextGen.Grok.Models.Req;
using Aco228.TextGen.Grok.Models.Res;
using Aco228.WService;

namespace Aco228.TextGen.Grok.Services.Web;

public interface IGrokChatService : IGrokApiService
{
    [ApiPost("chat/completions")]
    Task<string> GetString(MessageRequest request);
    
    [ApiPost("chat/completions")]
    Task<MessageResponse> GetResponse(MessageRequest request);
}