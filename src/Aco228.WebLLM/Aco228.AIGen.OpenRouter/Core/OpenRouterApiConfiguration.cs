using System.Net.Http.Headers;
using Aco228.WService.Base;

namespace Aco228.AIGen.OpenRouter.Core;

public class OpenRouterApiConfiguration : ApiServiceConf
{
    public override string BaseUrl => "https://openrouter.ai/api/v1/";
    private static string ApiKey { get; set; }

    public OpenRouterApiConfiguration()
    {
        ApiKey = Environment.GetEnvironmentVariable("OPENROUTER_API_KEY") ?? throw new InvalidOperationException("OpenRouterApiKey is not set");
    }

    public override HttpClient Prepare(HttpClient httpClient)
    {
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiKey);
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        httpClient.DefaultRequestHeaders.Add("X-Title", "ARBO");
        return httpClient;
    }
}