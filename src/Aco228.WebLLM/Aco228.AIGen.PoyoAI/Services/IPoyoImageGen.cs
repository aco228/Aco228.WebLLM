using Aco228.AIGen.Models;
using Aco228.AIGen.PoyoAI.Api;
using Aco228.AIGen.PoyoAI.Models;
using Aco228.AIGen.PoyoAI.Models.Images;
using Aco228.AIGen.Services;
using Aco228.Common.Extensions;
using Aco228.Common.Models;

namespace Aco228.AIGen.PoyoAI.Services;

public interface IPoyoImageGen : IImageGen, ITransient
{
    // Task<string> GenerateAndGetTaskId(PoyoModelType model, string prompt, ImageSize size = ImageSize.Square);
    // Task<ImageResponse> GetResponse(string taskId);
}

public class PoyoImageGen : ImageGen, IPoyoImageGen
{
    private readonly IPoyoApiService _apiService;

    public PoyoImageGen(IPoyoApiService apiService)
    {
        _apiService = apiService;
    } 

    public override async Task<List<GenerateImageResponse>> Generate(GenerateImageRequest prompt)
    {
        var modelType = Constants.PoyoImages.Models.FirstOrDefault(x => x.ModelApiName == prompt.ModelName);
        if (modelType == null)
            throw new ArgumentException("Invalid model name");

        var size = prompt.ImageSize.ToDefaultAspectRatio();
        var request = new ImageRequest()
        {
            model = modelType.ModelApiName,
            input = new()
            {
                prompt = prompt.Prompt,
                size = size,
            }
        };
        var response = await _apiService.GenerateImage(request);
        return new()
        {
            new()
            {
                Provider = ImageGenProvider.Poyo,
                Size = prompt.ImageSize,
                TaskId = response.data.task_id,
                ModelName = modelType.ModelApiName,
            }
        };
    }

    public override async Task<GenerateImageResponse?> GetResultFor(string taskId)
    {
        var result = await _apiService.GetStatus(taskId);
        if (result.data?.files?.Any() == false)
            return null;

        var file = result?.data?.files?.FirstOrDefault();
        if (file == null)
            return null;
        
        return new()
        {
            ImageUrl = file.file_url,
            Provider = ImageGenProvider.Poyo,
            Size = ImageSize.Unknown,
            ModelName = string.Empty,
        };
    }
}