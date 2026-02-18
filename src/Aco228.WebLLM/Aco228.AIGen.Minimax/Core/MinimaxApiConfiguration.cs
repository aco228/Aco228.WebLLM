using System.Net.Http.Headers;
using Aco228.WService.Base;

namespace Aco228.AIGen.Minimax.Core;

public class MinimaxApiConfiguration : ApiServiceConf
{
    public override string BaseUrl => "https://api.minimax.io/v1/";
    private static string ApiKey { get; set; }

    public MinimaxApiConfiguration()
    {
        ApiKey = Environment.GetEnvironmentVariable("MINIMAX_API_KEY") ?? throw new InvalidOperationException("MinimaxApiKey is not set");
    }

    public override HttpClient Prepare(HttpClient httpClient)
    {
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiKey);
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        return httpClient;
    }
}