using System.Text;
using Aco228.AIGen.ChatGPT.Constants;
using Aco228.AIGen.ChatGPT.Models.Web.Texts;
using Aco228.AIGen.ChatGPT.Services.Web;
using Aco228.AIGen.Models;
using Aco228.AIGen.Services;

namespace Aco228.AIGen.ChatGPT.Services;

public interface IChatGptTextGen : ITextGen
{
}

public class ChatGptTextGen : TextGenBase, IChatGptTextGen
{
    public override TextGenProvider Provider => TextGenProvider.ChatGPT;
    private readonly IChatGptTextApiService _textApiService;

    public ChatGptTextGen(IChatGptTextApiService textApiService)
    {
        _textApiService = textApiService;
    }
    
    public override void Prepare()
    {
        AddModels(ChatGptModelList.Models);
    }

    public override Task<string> Generate(TextGenerationRequest textGenerationRequest)
    {
        var request = new CreateTextRequest()
            .UseModel(textGenerationRequest.Model?.ModelApiName)
            .AddMessage(ModelRole.system, textGenerationRequest.System)
            .AddMessage(ModelRole.user, textGenerationRequest.Prompt, textGenerationRequest.FileUrls);
        
        return ProduceResponse(request);
    }

    public override Task<string> Generate(string prompt)
    {
        var request = new CreateTextRequest()
            .UseModel(TakeNextModel())
            .AddMessage(ModelRole.user, prompt);
        
        return ProduceResponse(request);
    }

    public override Task<string> Generate(string system, string prompt)
    {
        var request = new CreateTextRequest()
            .UseModel(TakeNextModel())
            .AddMessage(ModelRole.system, system)
            .AddMessage(ModelRole.user, prompt);
        
        return ProduceResponse(request);
    }

    public override Task<string> Generate(string model, string system, string prompt)
    {
        var request = new CreateTextRequest()
            .UseModel(model)
            .AddMessage(ModelRole.system, system)
            .AddMessage(ModelRole.user, prompt);
        
        return ProduceResponse(request);
    }

    private async Task<string> ProduceResponse(CreateTextRequest request)
    {
        var response = await _textApiService.GetResponse(request);
        
        var txtResponse = new StringBuilder();
        foreach (var output in response.output)
        {
            foreach (var contentDto in output.content)
                txtResponse.Append(contentDto.text);
        }
        
        return txtResponse.ToString();
    }
}