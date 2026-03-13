using System.Text;
using Aco228.Common.Models;
using Aco228.TextGen.Perplexity.Models;
using Aco228.TextGen.Perplexity.Models.Web;
using Aco228.TextGen.Perplexity.Services.Api;

namespace Aco228.TextGen.Perplexity.Services;

public interface IPerplexitySonarService : ITransient
{
    Task<PerplexitySonarResponse> Ask(string user, string? system = null);
}

public class PerplexitySonarService : IPerplexitySonarService
{
    private readonly IPerplexitySonarApiService _apiService;

    public PerplexitySonarService(IPerplexitySonarApiService apiService)
    {
        _apiService = apiService;
    }
    
    public async Task<PerplexitySonarResponse> Ask(string user, string? system = null)
    {
        var request = new SonarRequest();
        request.messages.Add(new()
        {
            role = "user",
            content = user,
        });
        if(!string.IsNullOrEmpty(system))
            request.messages.Add(new()
            {
                role = "system",
                content = user,
            });

        var response = await _apiService.GetResponse(request);
        var sb = new StringBuilder();
        foreach (var responseChoice in response.choices)
            sb.Append(responseChoice.message.content);
        
        var result = new PerplexitySonarResponse();
        result.Response = sb.ToString();
        return result;
    }
}