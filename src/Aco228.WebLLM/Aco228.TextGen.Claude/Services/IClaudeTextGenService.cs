using System.Text;
using Aco228.AIGen.Models;
using Aco228.AIGen.Services;
using Aco228.TextGen.Claude.Constants;
using Aco228.TextGen.Claude.Models.Web.Text;
using Aco228.TextGen.Claude.Services.Web;

namespace Aco228.TextGen.Claude.Services;

public interface IClaudeTextGenService : ITextGen { }

public class ClaudeTextGenService : TextGenBase, IClaudeTextGenService
{
    private readonly IClaudeChatApiService _service;
    public override TextGenProvider Provider => TextGenProvider.Claude;

    public ClaudeTextGenService(IClaudeChatApiService service)
    {
        _service = service;
    }
    
    public override void Prepare()
    {
        AddModels(ClaudeModelList.Models);
    }

    protected override async Task<TextGenResponse> ExecuteRequest(TextGenRequest request)
    {
        var result = new TextGenResponse();
        var apiRequest = CreateRequest(request);

        var txtResponse = new StringBuilder();
        var apiResponse = await _service.GetResponse(apiRequest);
        result.InputTokens = apiResponse.usage.input_tokens;
        result.OutputTokens = apiResponse.usage.output_tokens;
        
        foreach (var contentDto in apiResponse.content)
            txtResponse.Append(contentDto.text);

        result.Response = txtResponse.ToString();
        return result;
    }

    private MessageRequest CreateRequest(TextGenRequest request)
    {
        var apiRequest = new MessageRequest()
        {
            model = request.Model.ModelApiName,
        };
        
        apiRequest.AddInput("user", request.User, request.ImageUrls);
        if (!string.IsNullOrEmpty(request.System))
            apiRequest.system = request.System;
        
        return apiRequest;
    }
}