using Aco228.Common.Services;
using Aco228.WService.Base;

namespace Aco228.AIGen.FalAi.Core;

public class FalAiServiceConfiguration : ApiServiceConf
{
    public override string BaseUrl => "https://fal.run/";
    private static string ApiKey { get; set; }

    public FalAiServiceConfiguration(ISecretProvider secretProvider)
    {
        ApiKey = secretProvider.Get("FAL_AI_API") ?? throw new InvalidOperationException("FAL_AI_API is not set");
    }

    override public HttpClient Prepare(HttpClient httpClient)
    {
        httpClient.DefaultRequestHeaders.Add("Authorization", $"Key {ApiKey}");
        return httpClient;
    }
}