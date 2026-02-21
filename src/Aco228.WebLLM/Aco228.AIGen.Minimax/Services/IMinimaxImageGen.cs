using Aco228.AIGen.Minimax.Models.Web.Image;
using Aco228.AIGen.Minimax.Services.Web;
using Aco228.AIGen.Models;
using Aco228.AIGen.Services;
using Aco228.Common.Models;

namespace Aco228.AIGen.Minimax.Services;

public interface IMinimaxImageGen : IImageGen, ITransient
{
    
}

public class MinimaxImageGen : ImageGen, IMinimaxImageGen
{
    private readonly IMinimaxImageApiService _apiService;

    public MinimaxImageGen(IMinimaxImageApiService apiService)
    {
        _apiService = apiService;
    }
    
    public override async Task<List<GenerateImageResponse>> Generate(GenerateImageRequest prompt)
    {
        var modelType = Constants.MinimaxImageModels.Models.FirstOrDefault(x => x.ModelApiName == prompt.ModelName);
        if (modelType == null)
            throw new ArgumentException($"Invalid model name");

        var request = new MinimaxImageRequest()
        {
            model = modelType.ModelApiName,
            prompt = prompt.Prompt,
            aspect_ratio =  prompt.ImageSize.ToDefaultAspectRatio(),
            n = prompt.Count,
        };

        var response = await _apiService.GetResponse(request);
        
        var result = new List<GenerateImageResponse>();
        foreach (var urls in response.data.image_urls)
        {
            result.Add(new()
            {
                Provider = ImageGenProvider.Minimax,
                Size = prompt.ImageSize,
                ImageUrl = urls,
                ModelName = modelType.ModelApiName,
            });
        }

        return result;
    }

    public override HttpClient GetHttpClient()
        => _apiService.HttpClient;
}