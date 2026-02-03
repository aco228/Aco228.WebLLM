using Aco228.TextGen.DeepSeek.Code;
using Aco228.TextGen.DeepSeek.Models.Req;
using Aco228.TextGen.DeepSeek.Models.Res;
using Aco228.WService;

namespace Aco228.TextGen.DeepSeek.Services.Web;

public interface IDeepseekChatService : IDeepseekApiService
{
    [ApiPost("chat/completions")]
    Task<MessageResponse> GetResponse(MessageRequest request);
    
    [ApiPost("chat/completions")]
    Task<string> GetString(MessageRequest request);
}