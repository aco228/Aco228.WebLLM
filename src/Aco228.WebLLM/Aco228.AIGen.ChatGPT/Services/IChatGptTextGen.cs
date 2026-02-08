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

    protected override async Task<TextGenResponse> ExecuteRequest(TextGenRequest request)
    {
        var result = new TextGenResponse();
        var apiRequest = CreateRequest(request);
       
        var apiResponse = await _textApiService.GetResponse(apiRequest);
        result.InputTokens = apiResponse.usage.input_tokens;
        result.OutputTokens = apiResponse.usage.output_tokens;

        var txtResponse = new StringBuilder();
        foreach (var outputDto in apiResponse.output.Where(x => x.content?.Any() == true))
        foreach (var contentDto in outputDto.content)
            txtResponse.Append(contentDto.text);
        
        result.Response = txtResponse.ToString();
        return result;
    }

    private CreateTextRequest CreateRequest(TextGenRequest request)
    {
        var apiRequest = new CreateTextRequest()
        {
            Model = request.Model.ModelApiName,
        };
        
        apiRequest.AddInput("user", request.User, request.ImageUrls);
        if(!string.IsNullOrEmpty(request.System))
            apiRequest.AddInput("system", request.System);
        
        return apiRequest;
    }
}