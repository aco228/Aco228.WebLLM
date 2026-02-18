using Aco228.AIGen.Recraft.Core;
using Aco228.AIGen.Recraft.Models.Images;
using Aco228.WService;
using Aco228.WService.Base;

namespace Aco228.AIGen.Recraft.Services.Web;

public interface IRecraftImageApiService : IRecraftApiService
{
    [ApiPost("images/generations")]
    Task<string> GetString(RecraftImageRequest request);
    
    [ApiPost("images/generations")]
    Task<RecraftImageResponse> Get(RecraftImageRequest request);
}