using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using Aco228.AIGen.Helpers;
using Aco228.Common.Models;
using Aco228.TextGen.Perplexity.Models;
using Aco228.TextGen.Perplexity.Models.Web;
using Aco228.TextGen.Perplexity.Services.Api;
using Newtonsoft.Json;

namespace Aco228.TextGen.Perplexity.Services;

public interface IPerplexitySonarService : ITransient
{
    Task<PerplexitySonarResponse> Ask(string user, string? system = null);
    Task<T?> AskJson<T>( string user, string? system = null);
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

    public async Task<T?> AskJson<T>(string user, string? system = null)
    {
        var res = await Ask(user, system);
        var rawResponse = res.Response.Trim();
        if (rawResponse.StartsWith("```json")) rawResponse = rawResponse.Substring("```json".Length);
        if (rawResponse.EndsWith("```")) rawResponse = rawResponse.Substring(0, rawResponse.Length - "```".Length);
        rawResponse = rawResponse.Trim();
        
        var isResponseList = typeof(T).IsGenericType && typeof(T).GetGenericTypeDefinition() == typeof(List<>);
        var regexPattern = isResponseList ? @"\[.*\]" : @"\{.*\}";
        
        var matches = Regex.Matches(rawResponse, regexPattern, RegexOptions.Singleline);
        if (matches.Count > 0)
            rawResponse = matches[^1].Value;

        try
        {
            return PromptHelper.DeserializeResponse<T>(rawResponse);    
        }
        catch (Exception ex)
        {
            return default;
        }
        
    }
}