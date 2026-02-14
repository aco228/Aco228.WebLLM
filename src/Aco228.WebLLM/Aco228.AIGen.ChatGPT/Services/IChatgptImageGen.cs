using Aco228.AIGen.ChatGPT.Models;
using Aco228.AIGen.ChatGPT.Services.Web;
using Aco228.AIGen.Models;
using Aco228.AIGen.Services;
using Aco228.Common.Extensions;
using Aco228.Common.Helpers;
using Aco228.Common.LocalStorage;
using Aco228.Common.Models;
using GenerateImageRequest = Aco228.AIGen.ChatGPT.Models.Web.Images.GenerateImageRequest;
using GenerateImageResponse = Aco228.AIGen.Models.GenerateImageResponse;

namespace Aco228.AIGen.ChatGPT.Services;

public interface IChatgptImageGen : IImageGen, ITransient
{
}

public class ChatgptImageGen : ImageGen, IChatgptImageGen
{
    private readonly IChatgptImageApiService _apiService;

    public ChatgptImageGen(IChatgptImageApiService apiService)
    {
        _apiService = apiService;
    }
    
    public override async Task<List<GenerateImageResponse>> Generate(AIGen.Models.GenerateImageRequest prompt)
    {
        var modelType = Constants.ChatGptImageModelList.Models.FirstOrDefault(x => x.ModelApiName == prompt.ModelName);
        if(modelType == null)
            throw new ArgumentException("Invalid model name");

        var qualityString = prompt.Quality switch
        {
            ImageGenerationQuality.High => "high",
            ImageGenerationQuality.Medium => "medium",
            ImageGenerationQuality.Low => "low",
            _ => throw new ArgumentOutOfRangeException(nameof(prompt.Quality), prompt.Quality, null)
        };
       
        var request = new GenerateImageRequest()
        {
            prompt = prompt.Prompt,
            Count = prompt.Count,
            model = modelType.ModelApiName,
            size = prompt.ImageSize.ToDefaultSizeString(),
            quality = qualityString,
        };
        
        var result = new List<GenerateImageResponse>();
        var response = await _apiService.GenerateImage(request);
        var tempFolder = StorageManager.Instance.GetTempFolder();
        
        foreach (var imageData in response.data)
        {
            var imagePath = tempFolder.GetPathForFile($"{IdHelper.GetId()}.png");
            await File.WriteAllBytesAsync(imagePath, Convert.FromBase64String(imageData.b64_json));
            result.Add(new()
            {
                Size = prompt.ImageSize,
                Provider = ImageGenProvider.OpenAI,
                LocalFilePath = imagePath
            });
        }

        return result;
    }
}