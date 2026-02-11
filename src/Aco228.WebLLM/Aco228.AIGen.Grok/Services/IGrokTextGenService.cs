using System.Text;
using Aco228.AIGen.Grok.Constants;
using Aco228.AIGen.Grok.Models.Text;
using Aco228.AIGen.Grok.Services.Web;
using Aco228.AIGen.Models;
using Aco228.AIGen.Services;

namespace Aco228.AIGen.Grok.Services;

public interface IGrokTextGenService : ITextGen { }

public class GrokTextGenService : TextGenBase, IGrokTextGenService
{
    private readonly IGrokChatService _service;
    public override TextGenProvider Provider => TextGenProvider.Grok;

    public GrokTextGenService(IGrokChatService service)
    {
        _service = service;
    }
    
    public override void Prepare()
    {
        AddModels(GrokModelList.Models);
    }

    protected override async Task<TextGenResponse> ExecuteRequest(TextGenRequest request)
    {
        var result = new TextGenResponse();
        
        var apiRequest = CreateRequest(request);
        var apiResponse = await _service.GetResponse(apiRequest);
        result.InputTokens = apiResponse.usage.prompt_tokens;
        result.OutputTokens = apiResponse.usage.completion_tokens;

        var txtResponse = new StringBuilder();
        foreach (var apiResponseChoice in apiResponse.choices)
            txtResponse.Append(apiResponseChoice.message.content);

        result.Response = txtResponse.ToString();
        return result;
    }

    private MessageRequest CreateRequest(TextGenRequest request)
    {
        var result = new MessageRequest()
        {
            model = request.Model.ModelApiName,
        };
        
        result.AddInput("user", request.User, request.ImageUrls);
        if(!string.IsNullOrEmpty(request.System))
            result.AddInput("system", request.System);

        return result;
    }
}