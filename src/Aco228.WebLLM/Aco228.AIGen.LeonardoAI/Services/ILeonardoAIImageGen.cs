using Aco228.AIGen.LeonardoAI.Models;
using Aco228.AIGen.LeonardoAI.Models.Generations;
using Aco228.AIGen.LeonardoAI.Services.Api;
using Aco228.AIGen.Models;
using Aco228.AIGen.Services;
using Aco228.Common.Models;
using Aco228.AIGen.LeonardoAI.Constants;

namespace Aco228.AIGen.LeonardoAI.Services;

public interface ILeonardoAIImageGen : IImageGen, ITransient
{
    
}

public class LeonardoAIImageGen : ImageGen, ILeonardoAIImageGen
{
    private readonly ILeonardoGenerationApiService _apiService;

    public LeonardoAIImageGen(ILeonardoGenerationApiService apiService)
    {
        _apiService = apiService;
    }

    public override HttpClient GetHttpClient()
        => _apiService.HttpClient;
    
    public override async Task<List<GenerateImageResponse>> Generate(GenerateImageRequest prompt)
    {
        var modelType = Constants.LeonardoImageModels.Models.FirstOrDefault(x => x.ModelApiName == prompt.ModelName);
        if (modelType == null)
            modelType = Constants.LeonardoImageModels.Models.FirstOrDefault(x => x.Name == LeonardoImageModelType.LucidOrigin.ToString());
        
        int width, height = 0;
        if (prompt.ImageSize == ImageSize.Square)
        {
            width = height = 1024;
        } 
        else if (prompt.ImageSize == ImageSize.MiniPortrait)
        {
            width = 1072;
            height = 1344;
        }
        else if (prompt.ImageSize == ImageSize.Portrait || prompt.ImageSize == ImageSize.StoryReel)
        {
            width = 992;
            height = 1488;
        }
        else 
            throw new ArgumentException($"ImageSize: {prompt.ImageSize} is not supported");
        
        var apiRequest = new LeonardoGenerateRequest()
        {
            modelId = modelType.ModelApiName,
            width = width,
            height = height,
            prompt = prompt.Prompt,
            num_images = prompt.Count,
        };

        var apiResponse = await _apiService.Generate(apiRequest);
        var response = new List<GenerateImageResponse>();
        response.Add(new()
        {
            Provider = ImageGenProvider.LeonardoAI,
            ModelName = modelType.ModelApiName,
            Size = prompt.ImageSize,
            TaskId = apiResponse.Job.generationId,
        });

        return response;
    }

    public async Task<GenerateImageResponse?> GetResultFor(string taskId)
    {
        var status = await _apiService.GetGenerationStatus(taskId);
        if (string.IsNullOrEmpty(status?.Job?.generated_images?.FirstOrDefault()?.url))
            return null;

        return new()
        {
            Provider = ImageGenProvider.LeonardoAI,
            ImageUrl = status.Job.generated_images.FirstOrDefault().url,
            Size = ImageSize.Unknown,
            ModelName = string.Empty,
        };
    }
}