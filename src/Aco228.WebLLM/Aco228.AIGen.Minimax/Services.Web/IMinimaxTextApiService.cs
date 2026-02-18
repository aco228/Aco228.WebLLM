using Aco228.AIGen.Minimax.Core;
using Aco228.AIGen.Minimax.Models.Web.Text;
using Aco228.WService;

namespace Aco228.AIGen.Minimax.Services.Web;

/// <summary>
/// https://platform.minimax.io/docs/api-reference/text-chat
/// </summary>
public interface IMinimaxTextApiService : IMinimaxApiService
{
    [ApiPost("text/chatcompletion_v2")]
    Task<string> GetResponseString(MinimaxTextRequest request);
    
    [ApiPost("text/chatcompletion_v2")]
    Task<MinimaxTextResponse> GetResponse(MinimaxTextRequest request);
}