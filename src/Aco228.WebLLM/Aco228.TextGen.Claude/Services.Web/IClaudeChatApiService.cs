using Aco228.TextGen.Claude.Code;
using Aco228.TextGen.Claude.Models.Web.Text;
using Aco228.WService;

namespace Aco228.TextGen.Claude.Services.Web;

public interface IClaudeChatApiService : IClaudeApiService
{
    [ApiPost("messages")]
    Task<MessageResponse> GetResponse(MessageRequest request);
    
    [ApiPost("messages")]
    Task<string> GetString(MessageRequest request);
}