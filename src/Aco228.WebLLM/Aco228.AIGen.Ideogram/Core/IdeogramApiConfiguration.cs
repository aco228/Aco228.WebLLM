using Aco228.Common.Services;
using Aco228.WService.Base;

namespace Aco228.AIGen.Ideogram.Core;

public class IdeogramApiConfiguration : ApiServiceConf
{
    public override string BaseUrl => "https://api.ideogram.ai/v1/";
    private static string ApiKey { get; set; }

    public IdeogramApiConfiguration(ISecretProvider sp)
    {
        ApiKey = sp.Get("IDEOGRAM_API_KEY") ?? throw new InvalidOperationException("IdeogramApiKey is not set");
    }

    public override HttpClient Prepare(HttpClient httpClient)
    {
        httpClient.DefaultRequestHeaders.Add("Api-Key", $"{ApiKey}");
        return httpClient;
    }
}