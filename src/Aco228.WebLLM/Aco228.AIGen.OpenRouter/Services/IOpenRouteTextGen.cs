using System.Text;
using Aco228.AIGen.Models;
using Aco228.AIGen.OpenRouter.Models.Web.Text;
using Aco228.AIGen.OpenRouter.Services.Web;
using Aco228.AIGen.Services;

namespace Aco228.AIGen.OpenRouter.Services;

public interface IOpenRouteTextGen : ITextGen
{
    
}

public class OpenRouteTextGen : TextGenBase, IOpenRouteTextGen
{
    private readonly IOpenRouterTextApiService _apiService;
    public override TextGenProvider Provider => TextGenProvider.OpenRouter;

    public OpenRouteTextGen(IOpenRouterTextApiService apiService)
    {
        _apiService = apiService;
    }
    
    public override void Prepare()
    {
        AddModels(Constants.OpenRouterModelList.Models);
    }

    protected override async Task<TextGenResponse> ExecuteRequest(TextGenRequest request)
    {
        var result = new TextGenResponse();
        var apiRequest = PrepareRequest(request);

        var apiResponse = await _apiService.GenerateText(apiRequest);
        result.InputTokens = apiResponse.usage.input_tokens;
        result.OutputTokens = apiResponse.usage.output_tokens;
        
        var txtResponse = new StringBuilder();
        foreach (var responseText in apiResponse.output)
        foreach (var contentDto in responseText.content)
            txtResponse.Append(contentDto.text);
        
        result.Response = txtResponse.ToString();
        return result;
    }

    private OpenRouterTextRequest PrepareRequest(TextGenRequest request)
    {
        var apiRequest = new OpenRouterTextRequest();
        apiRequest.model = request.Model.ModelApiName;

        if (!string.IsNullOrEmpty(request.System))
            apiRequest.AddInput("system", request.System);
        
        apiRequest.AddInput("user", request.User, request.ImageUrls);
        return apiRequest;
    }
}