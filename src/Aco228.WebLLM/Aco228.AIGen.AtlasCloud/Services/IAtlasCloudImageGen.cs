using Aco228.AIGen.AtlasCloud.Models.Images;
using Aco228.AIGen.AtlasCloud.Services.Web;
using Aco228.AIGen.Models;
using Aco228.AIGen.Services;
using Aco228.Common.Models;

namespace Aco228.AIGen.AtlasCloud.Services;

public interface IAtlasCloudImageGen : IImageGen, ITransient
{
    
}

public class AtlasCLoudImageGen : ImageGen, IAtlasCloudImageGen
{
    private readonly IAtlasCloudImageApiService _apiService;

    public AtlasCLoudImageGen(
        IAtlasCloudImageApiService apiService)
    {
        _apiService = apiService;
    }
    
    public override async Task<List<GenerateImageResponse>> Generate(GenerateImageRequest prompt)
    {
        var modelType = Constants.AtlasCloudImageModels.Models.FirstOrDefault(x => x.ModelApiName == prompt.ModelName);
        if (modelType == null)
            throw new ArgumentException("Invalid model name");

        var request = new AtlasCloudImageRequest()
        {
            prompt = prompt.Prompt,
            model = modelType.ModelApiName,
            aspect_ratio = prompt.ImageSize.ToDefaultAspectRatio(),
        };

        var response = await _apiService.Get(request);
        var result = new List<GenerateImageResponse>();
        
        if(!(response.data.outputs is null))
        {
            foreach (var outputUrl in response.data.outputs)
                result.Add(new()
                {
                    Provider = ImageGenProvider.AtlasCloud,
                    ModelName = modelType.ModelApiName,
                    Size = prompt.ImageSize,
                    ImageUrl = outputUrl,
                });
            return result;
        }

        for (int i = 0; i < prompt.Count; i++)
        {
            result.Add(new()
            {
                Provider = ImageGenProvider.AtlasCloud,
                ModelName = modelType.ModelApiName,
                Size = prompt.ImageSize,
                TaskId = response.data.id,
            });
        }

        return result;
    }

    public override HttpClient GetHttpClient()
        => _apiService.HttpClient;

    public override async Task<GenerateImageResponse?> GetResultForInternal(string taskId)
    {
        var response = await _apiService.GetResult(taskId);

        if (response.data.outputs is null)
            return null;

        var result = new GenerateImageResponse()
        {
            Provider = ImageGenProvider.AtlasCloud,
            ModelName = string.Empty,
            Size = ImageSize.Unknown,
            ImageUrl = response.data.outputs.First(),
        };
        
        return result;
    }
}