using Aco228.Common;
using Aco228.GoogleServices.Models;
using Aco228.GoogleServices.Services;
using Aco228.WService.Base;

namespace Aco228.AIGen.Gemini.Code;

public class GeminiApiConfiguration : ApiServiceConf
{
    public override string BaseUrl => $"https://generativelanguage.googleapis.com/v1beta/models/";
    private static string ApiKey { get; set; }

    public GeminiApiConfiguration()
    {
        ApiKey = Environment.GetEnvironmentVariable("GOOGLE_AI_STUDIO_API_KEY") ?? throw new InvalidOperationException("GeminiApiKey is not set");
    }

    public override HttpClient Prepare(HttpClient httpClient)
    {
        httpClient.DefaultRequestHeaders.Add("x-goog-api-key", ApiKey);
        return httpClient;
    }
}