using Aco228.WService;
using Aco228.WService.Base;

namespace Aco228.AIGen.ChatGPT.Core;

public class ChatGptApiConfiguration : ApiServiceConf
{
    public override string BaseUrl => "https://api.openai.com/";
    internal string ApiKey { get; set; }

    public ChatGptApiConfiguration()
    {
        var apiKey = Environment.GetEnvironmentVariable("CHAT_GPT_API");
        if(string.IsNullOrEmpty(apiKey))
            throw new InvalidOperationException("ChatGPTWebApiKey is not set");

        ApiKey = apiKey;
    }
    
    public override void Prepare(HttpClient httpClient)
    {
        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {ApiKey}");
        // AddDefaultHeader("OpenAI-Beta", $"assistants=v1");
    }

    public override void OnBeforeRequest(WebApiMethodType methodType, ref string url, ref HttpContent? httpContent, string? httpContentString)
    {
        Console.WriteLine($"OnBeforeRequest: [{methodType}].{url} :: {httpContentString}");
    }

    public override void OnResponseReceived(WebApiMethodType methodType, string url, HttpContent? httpContent, string? httpContentString, HttpResponseMessage response, string stringResponse)
    {
        Console.WriteLine($"OnStringReceived: [{methodType}].{url} :: {httpContentString}");
        Console.WriteLine(stringResponse);
    }
}