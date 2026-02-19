using Aco228.AIGen.BlackForestLabs.Models.Images;
using Aco228.AIGen.BlackForestLabs.Services.Web;
using Aco228.AIGen.Models;
using Aco228.AIGen.Services;
using Aco228.Common.Models;

namespace Aco228.AIGen.BlackForestLabs.Services;

public interface IBlackForestLabsImageGen : IImageGen, ITransient
{
    
}

public class BlackForestLabsImageGen : ImageGen, IBlackForestLabsImageGen
{
    private readonly IBlackForestLabImageApiService _apiService;

    public BlackForestLabsImageGen(IBlackForestLabImageApiService apiService)
    {
        _apiService = apiService;
    }
    
    public override async Task<List<GenerateImageResponse>> Generate(GenerateImageRequest prompt)
    {
        var modelType = Constants.BlackForestImageModels.Models.FirstOrDefault(x => x.ModelApiName == prompt.ModelName);
        if (modelType == null)
            throw new ArgumentException("Invalid model name");

        var size = prompt.ImageSize.ToDefaultSizeString();
        var sizeSplit = size.Split("x");

        var request = new BlackForestLabsImageRequest()
        {
            prompt = prompt.Prompt,
            height = int.Parse(sizeSplit[0]),
            width = int.Parse(sizeSplit[1]),
        };

        var response = await _apiService.Get(modelType.ModelApiName, request);
        var result = new List<GenerateImageResponse>();
        result.Add(new()
        {
            Provider = ImageGenProvider.BlackForestLabs,
            ModelName = modelType.ModelApiName,
            Size = prompt.ImageSize,
            TaskId = response.id,
        });

        return result;
    }

    public override async Task<GenerateImageResponse?> GetResultForInternal(string taskId)
    {
        var response = await _apiService.GetResult(taskId);
        var url = response?.result?.sample;
        if (string.IsNullOrEmpty(url))
            return null;

        var result = new GenerateImageResponse()
        {
            Provider = ImageGenProvider.BlackForestLabs,
            ImageUrl = url,
            TaskId = taskId,
            ModelName = string.Empty,
            Size = ImageSize.Unknown,
        };

        return result;
    }
}