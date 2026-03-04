using Aco228.Common.Services;
using Aco228.WService.Base;

namespace Aco228.AIGen.PoyoAI.Core;

public class PoyoApiServiceConfiguration : ApiServiceConf
{
    private readonly string ApiKey = null;
    public override string BaseUrl => "https://api.poyo.ai/api/";

    public PoyoApiServiceConfiguration(ISecretProvider secretProvider)
    {
        ApiKey = secretProvider.Get("POYO_AI") ?? throw new InvalidOperationException("PoyoApiKey is not set");
    }

    public override HttpClient Prepare(HttpClient httpClient)
    {
        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {ApiKey}");
        return httpClient;
    }
}