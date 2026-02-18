using Aco228.WService.Base;

namespace Aco228.AIGen.BlackForestLabs.Core;

public class BlackForestLabsApiConfiguration : ApiServiceConf
{
    public override string BaseUrl => "https://api.bfl.ai/v1/";
    private static string ApiKey { get; set; }

    public BlackForestLabsApiConfiguration()
    {
        ApiKey = Environment.GetEnvironmentVariable("BLACK_FOREST_LABS_API_KEY") ?? throw new InvalidOperationException("BlackForestLabsApiKey is not set");
    }

    public override HttpClient Prepare(HttpClient httpClient)
    {
        httpClient.DefaultRequestHeaders.Add("x-key", $"{ApiKey}");
        return httpClient;
    }
}