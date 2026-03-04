using Aco228.Common.Services;
using Aco228.WService;
using Aco228.WService.Base;

namespace Aco228.AIGen.ChatGPT.Core;

public class ChatGptApiConfiguration : ApiServiceConf
{
    public override string BaseUrl => "https://api.openai.com/";
    internal string ApiKey { get; set; }

    public ChatGptApiConfiguration(ISecretProvider secretProvider)
    {
        var apiKey = secretProvider.Get("CHAT_GPT_API");
        if(string.IsNullOrEmpty(apiKey))
            throw new InvalidOperationException("ChatGPTWebApiKey is not set");

        ApiKey = apiKey;
    }
    
    public override HttpClient Prepare(HttpClient httpClient)
    {
        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {ApiKey}");
        return httpClient;
    }
}