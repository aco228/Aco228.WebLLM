using Aco228.WService;
using Aco228.WService.Base;

namespace Aco228.TextGen.DeepSeek.Code;

public class DeepseekApiConfiguration : ApiServiceConf
{
    public override string BaseUrl => "https://api.deepseek.com/";
    private static string ApiKey { get; set; }

    public DeepseekApiConfiguration()
    {
        ApiKey = Environment.GetEnvironmentVariable("DEEPSEEK_API_KEY") ?? throw new InvalidOperationException("DeepseekApiKey is not set");
    }

    public override void Prepare(HttpClient httpClient)
    {
        httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + ApiKey);
    }

    public override void OnResponseReceived(WebApiMethodType methodType, string url, HttpContent? httpContent, string? httpContentString,
        HttpResponseMessage response, string stringResponse)
    {
        int a = 0;
    }
}