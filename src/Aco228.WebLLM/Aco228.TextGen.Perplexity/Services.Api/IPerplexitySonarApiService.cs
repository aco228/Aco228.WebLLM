using Aco228.TextGen.Perplexity.Core;
using Aco228.TextGen.Perplexity.Models.Web;
using Aco228.WService;

namespace Aco228.TextGen.Perplexity.Services.Api;

public interface IPerplexitySonarApiService : IPerplexityApiService
{
    [ApiPost("sonar")]
    Task<string> GetResponseRaw(SonarRequest request);
    
    [ApiPost("sonar")]
    Task<SonarResponse> GetResponse(SonarRequest request);
}