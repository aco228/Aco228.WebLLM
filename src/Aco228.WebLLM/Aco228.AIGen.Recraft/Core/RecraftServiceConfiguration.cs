using Aco228.Common.Services;
using Aco228.WService.Base;

namespace Aco228.AIGen.Recraft.Core;

public class RecraftServiceConfiguration : ApiServiceConf
{
    public override string BaseUrl => "https://external.api.recraft.ai/v1/";
    private static string ApiKey { get; set; }

    public RecraftServiceConfiguration(ISecretProvider sp)
    {
        ApiKey = sp.Get("RECRAFT_API_KEY") ?? throw new InvalidOperationException("RecraftApiKey is not set");
    }

    public override HttpClient Prepare(HttpClient httpClient)
    {
        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {ApiKey}");
        return httpClient;
    }
}