using System.Text;
using Aco228.AIGen.Gemini.Models.Gemini;
using Aco228.AIGen.Gemini.Services.Web.Gemini;
using Aco228.AIGen.Models;
using Aco228.AIGen.Services;

namespace Aco228.AIGen.Gemini.Services;

public interface IGeminiTextGen : ITextGen
{
    
}

public class GeminiTextGen : TextGenBase, IGeminiTextGen
{
    private readonly IGeminiTextApiService _service;
    public override TextGenProvider Provider => TextGenProvider.Gemini;

    public GeminiTextGen(IGeminiTextApiService service)
    {
        _service = service;
    }
    
    public override void Prepare()
    {
        AddModels(Constants.GeminiModelList.Models);
    }

    protected override async Task<TextGenResponse> ExecuteRequest(TextGenRequest request)
    {
        var result = new TextGenResponse();
        
        var apiRequest = CreateRequest(request);
        var apiResponse = await _service.GetResponse(request.Model.ModelApiName, apiRequest);
        result.InputTokens = 0;
        result.OutputTokens = 0;

        var sb = new StringBuilder();
        foreach (var responseText in apiResponse)
        {
            result.InputTokens += responseText.usageMetadata.promptTokenCount;
            result.OutputTokens += responseText.usageMetadata.candidatesTokenCount;
            
            foreach (var candidate in responseText.candidates)
            foreach (var candidatePart in candidate.content.parts)
                sb.Append(candidatePart.text);
        }

        result.Response = sb.ToString().Trim();
        return result;
    }

    private RequestText CreateRequest(TextGenRequest request)
    {
        var result = new RequestText();
        if(!string.IsNullOrEmpty(request.System))
            result.AddContent("system", request.System);
        
        result.AddContent("user", request.User, request.ImageUrls);
        return result;
    }
    
}