using Aco228.AIGen.Minimax.Core;
using Aco228.AIGen.Minimax.Models.Web.Image;
using Aco228.WService;

namespace Aco228.AIGen.Minimax.Services.Web;

public interface IMinimaxImageApiService : IMinimaxApiService
{
    [ApiPost("image_generation")]
    public Task<MinimaxImageResponse> GetResponse(MinimaxImageRequest request);
}