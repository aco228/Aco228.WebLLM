using Aco228.AIGen.FalAi.Models;
using Aco228.AIGen.FalAi.Models.Web;
using Aco228.AIGen.FalAi.Services.Api;
using Aco228.AIGen.Models;
using Aco228.AIGen.Services;
using Aco228.Common.Models;

namespace Aco228.AIGen.FalAi.Services;

public interface IFalImageGen : IImageGen, ITransient 
{
    
}

public class FalImageGen : ImageGen, IFalImageGen
{
    private readonly IFalAiTextToImageApiService _apiService;

    public FalImageGen(IFalAiTextToImageApiService apiService)
    {
        _apiService = apiService;
    }

    public override HttpClient GetHttpClient()
        => _apiService.HttpClient;
    
    public override async Task<List<GenerateImageResponse>> Generate(GenerateImageRequest prompt)
    {
        var modelType = Constants.ImageModels.Models.FirstOrDefault(x => x.ModelApiName == prompt.ModelName);
        if (modelType == null)
            throw new ArgumentException("Invalid model name");

        // FalImageSize size = prompt.ImageSize switch
        // {
        //     ImageSize.Square => FalImageSize.square_hd,
        //     ImageSize.MiniPortrait => FalImageSize.portrait_4_3,
        //     ImageSize.Portrait => FalImageSize.portrait_16_9,
        //     ImageSize.StoryReel => FalImageSize.portrait_16_9,
        //     _ => FalImageSize.square,
        // };

        var sizeString = prompt.ImageSize.ToDefaultSizeString();
        var sizeStringSplit = sizeString.Split('x');
        var sizeWidth = int.Parse(sizeStringSplit[0]);
        var sizeHeight = int.Parse(sizeStringSplit[1]);

        var request = new FalImageRequest()
        {
            prompt = prompt.Prompt,
            image_size = new()
            {
                width = sizeWidth,
                height = sizeHeight,
            },
            num_images = prompt.Count,
        };

        var response = await _apiService.RequestImage(modelType.ModelApiName, request);
        var result = new List<GenerateImageResponse>();
        foreach (var responseImage in response.images)
            result.Add(new()
            {
                ModelName = modelType.ModelApiName,
                Provider = ImageGenProvider.FalAi,
                Size = prompt.ImageSize,
                ImageUrl = responseImage.url,
            });

        return result;
    }

}