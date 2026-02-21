using System.Text;
using System.Text.Json;
using Aco228.AIGen.Minimax.Core;
using Aco228.AIGen.Minimax.Models.Web.Text;
using Aco228.AIGen.Minimax.Services.Web;
using Aco228.AIGen.Models;
using Aco228.AIGen.Services;

namespace Aco228.AIGen.Minimax.Services;

public interface IMinimaxTextGen : ITextGen
{
    
}

public class MinimaxTexGen : TextGenBase, IMinimaxTextGen
{
    private readonly IMinimaxTextApiService _apiService;
    public override TextGenProvider Provider => TextGenProvider.Minimax;

    public MinimaxTexGen(IMinimaxTextApiService apiService)
    {
        _apiService = apiService;
    }
    
    public override void Prepare()
    {
        AddModels(Constants.MinimaxTextModels.Models);
    }

    protected override async Task<TextGenResponse> ExecuteRequest(TextGenRequest request)
    {
        var response = new TextGenResponse();
        var apiRequest = PrepareRequest(request);
        
        var apiResponse = await _apiService.GetResponse(apiRequest);
        if (apiResponse == null)
        {
            return null;
        }
        response.InputTokens = apiResponse.usage.prompt_tokens;
        response.OutputTokens = apiResponse.usage.completion_tokens;

        var textResponse = new StringBuilder();
        foreach (var responseText in apiResponse.choices)
            textResponse.Append(responseText.message.content);
        
        response.Response = textResponse.ToString();
        return response;
    }

    private MinimaxTextRequest PrepareRequest(TextGenRequest request)
    {
        var apiRequest = new MinimaxTextRequest(){ model = request.Model.ModelApiName };
        apiRequest.AddMessage("user", request.User, request.ImageUrls);
        if(!string.IsNullOrEmpty(request.System))
            apiRequest.AddMessage("system", request.User);
        return apiRequest;
        
    }
}