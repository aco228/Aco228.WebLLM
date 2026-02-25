using Aco228.WService.Base;

namespace Aco228.AIGen.DeepAI.Core;

public class DeepAiApiConfiguration : ApiServiceConf
{
    public override string BaseUrl => "https://api.deepai.org/api/";
    private static string ApiKey { get; set; }

    public DeepAiApiConfiguration()
    {
        ApiKey = Environment.GetEnvironmentVariable("DEEP_AI_API_KEY") ?? throw new InvalidOperationException("DeepAiApiKey is not set");
    }

    public override HttpClient Prepare(HttpClient httpClient)
    {
        httpClient.DefaultRequestHeaders.Add("api-key", ApiKey);
        return httpClient;
    }
    
}