using Aco228.Common.Services;
using Aco228.WService.Base;
using YamlDotNet.Serialization.NodeTypeResolvers;

namespace Aco228.AIGen.Gemini.Code;

public class GoogleAiStudioApiConfiguration : ApiServiceConf
{
    public override string BaseUrl => $"https://generativelanguage.googleapis.com/v1beta/";
    private static string ApiKey { get; set; }

    public GoogleAiStudioApiConfiguration(ISecretProvider secretProvider)
    {
        ApiKey = secretProvider.Get("GOOGLE_AI_STUDIO_API_KEY") ?? throw new InvalidOperationException("GeminiApiKey is not set");
    }

    public string GetApiKey() => ApiKey;

    public override HttpClient Prepare(HttpClient httpClient)
    {
        httpClient.DefaultRequestHeaders.Add("x-goog-api-key", ApiKey);
        return httpClient;
    }
}