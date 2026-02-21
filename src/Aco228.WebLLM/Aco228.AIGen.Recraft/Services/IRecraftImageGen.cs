using Aco228.AIGen.Models;
using Aco228.AIGen.Recraft.Core;
using Aco228.AIGen.Recraft.Models.Images;
using Aco228.AIGen.Recraft.Services.Web;
using Aco228.AIGen.Services;
using Aco228.Common.Models;

namespace Aco228.AIGen.Recraft.Services;

public interface IRecraftImageGen : IImageGen, ITransient
{
    
}

public class RecraftImageGen : ImageGen, IRecraftImageGen
{
    private readonly IRecraftImageApiService _apiService;

    public RecraftImageGen(IRecraftImageApiService apiService)
    {
        _apiService = apiService;
    }
    
    public override async Task<List<GenerateImageResponse>> Generate(GenerateImageRequest prompt)
    {
        var modelType = Constants.RecraftImageModels.Models.FirstOrDefault(x => x.ModelApiName == prompt.ModelName);
        if (modelType == null)
            throw new ArgumentException("Invalid model name");

        var apiRequest = new RecraftImageRequest()
        {
            prompt = prompt.Prompt,
            model = modelType.ModelApiName,
            size = prompt.ImageSize.ToDefaultAspectRatio(),
            n = prompt.Count,
        };

        var response = await _apiService.Get(apiRequest);
        var result = new List<GenerateImageResponse>();
        foreach (var dataDto in response.data)
            result.Add(new()
            {
                Provider = ImageGenProvider.BlackForestLabs,
                ModelName = modelType.ModelApiName,
                Size = prompt.ImageSize,
                ImageUrl = dataDto.url,
            });

        return result;
    }

    public override HttpClient GetHttpClient()
        => _apiService.HttpClient;
}