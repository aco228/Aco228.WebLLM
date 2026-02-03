using Aco228.WService.Base;

namespace Aco228.TextGen.Grok.Code;

public class GrokApiConfiguration : ApiServiceConf
{
    public override string BaseUrl => "https://api.x.ai/v1/";
    private static string ApiKey { get; set; }

    public GrokApiConfiguration()
    {
        ApiKey = Environment.GetEnvironmentVariable("GROK_API_KEY") ?? throw new InvalidOperationException("GrokApiKey is not set");
    }

    public override void Prepare(HttpClient httpClient)
    {
        httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + ApiKey);
        httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
    }
}