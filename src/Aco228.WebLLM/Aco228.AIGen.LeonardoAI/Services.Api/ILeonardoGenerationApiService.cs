using Aco228.AIGen.LeonardoAI.Core;
using Aco228.AIGen.LeonardoAI.Models;
using Aco228.AIGen.LeonardoAI.Models.Generations;
using Aco228.WService;
using Aco228.WService.Models.Attributes.MethodAttributes;

namespace Aco228.AIGen.LeonardoAI.Services.Api;

public interface ILeonardoGenerationApiService : ILeonardoApiService
{
    [ApiGet("platformModels")]
    Task<LeonardoModelResponse> GetModels();
    
    [ApiPost("generations")]
    Task<string> GenerateRaw(LeonardoGenerateRequest request);
    
    [ApiPost("generations")]
    Task<LeonardoGenerationResponse> Generate(LeonardoGenerateRequest request);
    
    [ApiGet("generations/{id}")]
    Task<string> GetGenerationRaw(string id);
    
    [ApiGet("generations/{id}")]
    Task<LeonardoStatusResponse> GetGenerationStatus(string id);
}