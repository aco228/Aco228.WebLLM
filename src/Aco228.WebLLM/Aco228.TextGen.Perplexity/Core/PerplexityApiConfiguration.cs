using Aco228.Common.Services;
using Aco228.WService.Base;

namespace Aco228.TextGen.Perplexity.Core;

public class PerplexityApiConfiguration : ApiServiceConf
{
    public override string BaseUrl => "https://api.perplexity.ai/v1/";
    public static string ApiKey { get; set; }

    public PerplexityApiConfiguration(ISecretProvider sp)
    {
        ApiKey = sp.Get("PERPLEXITY_API_KEY") ?? throw new InvalidOperationException("PERPLEXITY_API_KEY is not set");
    }

    override public HttpClient Prepare(HttpClient httpClient)
    {
        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {ApiKey}");
        return httpClient;
    }
}