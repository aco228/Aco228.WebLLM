using Aco228.AIGen.Models;
using Aco228.AIGen.PoyoAI.Api;
using Aco228.AIGen.PoyoAI.Models;
using Aco228.AIGen.PoyoAI.Models.Images;

namespace Aco228.AIGen.PoyoAI.Services;

public interface IPoyoImageGen
{
    Task<string> GenerateAndGetTaskId(PoyoModelType model, string prompt, ImageSize size = ImageSize.Square);
    Task<ImageResponse> GetResponse(string taskId);
}

public class PoyoImageGen : IPoyoImageGen
{
    private readonly IPoyoApiService _apiService;

    public PoyoImageGen(IPoyoApiService apiService)
    {
        _apiService = apiService;
    }
    
    public async Task<string> GenerateAndGetTaskId(PoyoModelType model, string prompt, ImageSize size = ImageSize.Square)
    {
        string sizeString = size switch
        {
            ImageSize.Square => "1:1",
            ImageSize.Portrait => "16:9",
            ImageSize.Landscape => "9:16",
            _ => throw new ArgumentOutOfRangeException(nameof(size), size, null)
        };
        
        var request = new ImageRequest()
        {
            model = ModelTypeHelper.GetModelApiName(model),
            input = new()
            {
                prompt = prompt,
                size = sizeString,
            }
        };
        var response = await _apiService.GenerateImage(request);
        return response.data.task_id;
    }

    public Task<ImageResponse> GetResponse(string taskId)
        => _apiService.GetStatus(taskId);
}