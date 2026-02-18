using Aco228.AIGen.Ideogram.Models.Image;
using Aco228.AIGen.Ideogram.Services.Web;
using Aco228.AIGen.Models;
using Aco228.AIGen.Services;
using Aco228.Common.Models;

namespace Aco228.AIGen.Ideogram.Services;

public interface IIdeogramImageGen : IImageGen, ITransient
{
    
}

public class IdeogramImageGen : ImageGen, IIdeogramImageGen
{
    private readonly IIdeogramImageApiService _apiService;

    public IdeogramImageGen(IIdeogramImageApiService apiService)
    {
        _apiService = apiService;
    }
    
    public override async Task<List<GenerateImageResponse>> Generate(GenerateImageRequest prompt)
    {
        var modelType = Constants.IdeogramImageModels.Models.FirstOrDefault(x => x.ModelApiName == prompt.ModelName);
        if (modelType == null)
            throw new ArgumentException("Invalid model name");

        var renderingSpeed = prompt.Quality switch
        {
            ImageGenerationQuality.High => "QUALITY",
            ImageGenerationQuality.Medium => "DEFAULT",
            _ => "FLASH"
        };

        var request = new IdeogramImageRequest()
        {
            prompt = prompt.Prompt,
            aspect_ratio = prompt.ImageSize.ToDefaultAspectRatio().Replace(":", "x"),
            rendering_speed = renderingSpeed,
            num_images = prompt.Count,
        };

        var response = await _apiService.Get(request);
        var result = new List<GenerateImageResponse>();
        foreach (var ideogramImageResponseData in response.data)
            result.Add(new()
            {
                Provider = ImageGenProvider.Ideogram,
                ModelName = modelType.ModelApiName,
                Size = prompt.ImageSize,
                ImageUrl = ideogramImageResponseData.url,
            });

        return result;
    }
}