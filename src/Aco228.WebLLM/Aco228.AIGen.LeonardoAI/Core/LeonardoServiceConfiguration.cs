using Aco228.Common.Services;
using Aco228.WService.Base;

namespace Aco228.AIGen.LeonardoAI.Core;

public class LeonardoServiceConfiguration : ApiServiceConf
{
    public override string BaseUrl => "https://cloud.leonardo.ai/api/rest/v1/";
    private static string ApiKey { get; set; }

    public LeonardoServiceConfiguration(ISecretProvider secretProvider)
    {
        ApiKey = secretProvider.Get("LEONARDO_API_KEY") ?? throw new InvalidOperationException("LEONARDO_API_KEY is not set");
    }

    public override HttpClient Prepare(HttpClient httpClient)
    {
        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {ApiKey}");
        return httpClient;   
    }
}