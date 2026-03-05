using Aco228.AIGen.Gemini.Code;
using Aco228.AIGen.Gemini.Models.Gemini;
using Aco228.AIGen.Gemini.Models.GoogleAiStudio.Images;
using Aco228.WService;
using Aco228.WService.Attributes;
using Aco228.WService.Base;

namespace Aco228.AIGen.Gemini.Services.Web;

[ApiServiceDecorator(typeof(GoogleAiStudioApiConfiguration))]
public interface IGoogleAiStudioApiService : IApiService
{
    [ApiPost("models/{modelId}:streamGenerateContent")]
    Task<List<ResponseText>> GetResponse(string modelId, RequestText request);
    
    [ApiPost("models/{modelId}:generateContent")]
    Task<ResponseText> GetImage(string modelId, GoogleAiImageRequest request);
    
    [ApiPost("models/{modelId}:generateContent")]
    Task<string> GetImageString(string modelId, GoogleAiImageRequest request);
}