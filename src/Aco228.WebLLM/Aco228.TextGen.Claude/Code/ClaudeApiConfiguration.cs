using Aco228.WService.Base;

namespace Aco228.TextGen.Claude.Code;

public class ClaudeApiConfiguration : ApiServiceConf
{
    public override string BaseUrl => "https://api.anthropic.com/v1/";
    private static string ApiKey { get; set; }

    public ClaudeApiConfiguration()
    {
        ApiKey = Environment.GetEnvironmentVariable("CLAUDE_API_KEY") ?? throw new InvalidOperationException("ClaudeAIApiKey is not set");
    }

    public override HttpClient Prepare(HttpClient httpClient)
    {
        httpClient.DefaultRequestHeaders.Add("x-api-key", ApiKey);
        httpClient.DefaultRequestHeaders.Add("anthropic-version", "2023-06-01");
        return httpClient;
    }
}