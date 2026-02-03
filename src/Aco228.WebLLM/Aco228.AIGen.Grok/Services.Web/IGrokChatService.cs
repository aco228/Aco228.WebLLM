using Aco228.AIGen.Grok.Code;
using Aco228.AIGen.Grok.Models.Req;
using Aco228.AIGen.Grok.Models.Res;
using Aco228.WService;

namespace Aco228.AIGen.Grok.Services.Web;

public interface IGrokChatService : IGrokApiService
{
    [ApiPost("chat/completions")]
    Task<string> GetString(MessageRequest request);
    
    [ApiPost("chat/completions")]
    Task<MessageResponse> GetResponse(MessageRequest request);
}