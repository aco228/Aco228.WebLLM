using Aco228.AIGen.Models;
using Aco228.AIGen.PoyoAI.Api;
using Aco228.AIGen.PoyoAI.Models;
using Aco228.AIGen.PoyoAI.Models.Images;
using Aco228.AIGen.Services;
using Aco228.Common.Extensions;

namespace Aco228.AIGen.PoyoAI.Services;

public interface IPoyoImageGen : IImgGen
{
    // Task<string> GenerateAndGetTaskId(PoyoModelType model, string prompt, ImageSize size = ImageSize.Square);
    // Task<ImageResponse> GetResponse(string taskId);
}

public class PoyoImageGen : IPoyoImageGen
{
    private readonly IPoyoApiService _apiService;

    public PoyoImageGen(IPoyoApiService apiService)
    {
        _apiService = apiService;
    }
    
    public async Task<List<GenerateImageResponse>> Generate(GenerateImageRequest prompt)
    {
        var modelType = prompt.ModelName.ToEnumNull<PoyoModelType>();
        if (modelType == null)
            throw new ArgumentException("Invalid model name");

        var size = prompt.ImageSize.ToDefaultAspectRatio();
        var request = new ImageRequest()
        {
            model = ModelTypeHelper.GetModelApiName(modelType.Value),
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
                TaskId = response.data.task_id,
            }
        };
    }   
}