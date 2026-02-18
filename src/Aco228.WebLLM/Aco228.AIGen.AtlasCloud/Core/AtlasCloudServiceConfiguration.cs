using Aco228.WService.Base;

namespace Aco228.AIGen.AtlasCloud.Core;

public class AtlasCloudServiceConfiguration : ApiServiceConf
{
    public override string BaseUrl => "https://api.atlascloud.ai/api/v1/";
    private static string ApiKey { get; set; }

    public AtlasCloudServiceConfiguration()
    {
        ApiKey = Environment.GetEnvironmentVariable("ATLAS_CLOUD_API_KEY") ?? throw new InvalidOperationException("AtlasCloudApiKey is not set");
    }

    public override HttpClient Prepare(HttpClient httpClient)
    {
        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {ApiKey}");
        return httpClient;
    }
}