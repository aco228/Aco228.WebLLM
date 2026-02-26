using Aco228.AIGen.Gemini.Models.GoogleAiStudio.Images;
using Aco228.AIGen.Gemini.Services.Web;
using Aco228.AIGen.Models;
using Aco228.AIGen.Services;
using Aco228.Common.Helpers;
using Aco228.Common.Infrastructure;
using Aco228.Common.LocalStorage;
using Aco228.Common.Models;

namespace Aco228.AIGen.Gemini.Services;

public interface INanoBananaImageGen : IImageGen, ITransient
{
    
}

public class NanoBananaImageGen : ImageGen, INanoBananaImageGen
{
    private readonly IGoogleAiStudioApiService _apiService;
    public TextGenProvider Provider  => TextGenProvider.NanoBanana;

    public NanoBananaImageGen(
        IGoogleAiStudioApiService apiService)
    {
        _apiService = apiService;
    }
    
    public override HttpClient GetHttpClient() => _apiService.HttpClient;

    public override async Task<List<GenerateImageResponse>> Generate(GenerateImageRequest prompt)
    {
        var modelType = Constants.GoogleAiStudioImageModelList.Models.FirstOrDefault(x => x.ModelApiName == prompt.ModelName);
        if (modelType == null)
            throw new ArgumentException("Invalid model name");

        var request = new GoogleAiImageRequest();
        request.AddContent(prompt.Prompt);
        request.generationConfig.imageConfig.aspectRatio = prompt.ImageSize.ToDefaultAspectRatio();
        request.generationConfig.imageConfig.imageSize = prompt.Quality switch
        {
            ImageGenerationQuality.High => "4k",
            ImageGenerationQuality.Medium => "2k",
            ImageGenerationQuality.Low => "1k",
        };

        var response = await _apiService.GetImage(modelType.ModelApiName, request);
        var result = new List<GenerateImageResponse>();
        var tempFolder = StorageManager.Instance.GetTempFolder();
        foreach (var responseCandidate in response.candidates)
        foreach (var responsePart in responseCandidate.content.parts)
        {
            if(responsePart.inlineData == null) continue;
            
            var imagePath = tempFolder.GetPathForFile($"{IdHelper.GetId()}.png");
            await File.WriteAllBytesAsync(imagePath, Convert.FromBase64String(responsePart.inlineData.data));
            result.Add(new()
            {
                Size = prompt.ImageSize,
                Provider = ImageGenProvider.GoogleAiStudio,
                LocalFilePath = imagePath,
                ModelName = modelType.ModelApiName,
            });
        }

        return result;
    }

}