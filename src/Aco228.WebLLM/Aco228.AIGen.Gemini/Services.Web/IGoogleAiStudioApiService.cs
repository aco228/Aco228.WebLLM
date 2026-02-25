using Aco228.AIGen.Gemini.Code;
using Aco228.AIGen.Gemini.Models.Gemini;
using Aco228.WService;
using Aco228.WService.Attributes;
using Aco228.WService.Base;

namespace Aco228.AIGen.Gemini.Services.Web;

[ApiServiceDecorator(typeof(GeminiApiConfiguration))]
public interface IGoogleAiStudioApiService : IApiService
{
    [ApiPost("{modelId}:streamGenerateContent")]
    Task<List<ResponseText>> GetResponse(string modelId, RequestText request);
}