using Aco228.AIGen.Models;
using Aco228.AIGen.OpenRouter.Services.Web;
using Aco228.AIGen.Services;
using Aco228.Common.Helpers;
using Aco228.Common.LocalStorage;
using Aco228.Common.Models;

namespace Aco228.AIGen.OpenRouter.Services;

public interface IOpenRouterImageGen : IImageGen, ITransient
{
    
}

public class OpenRouterImageGen : ImageGen, IOpenRouterImageGen
{
    private readonly IOpenRouterImageApiService _service;

    public OpenRouterImageGen(IOpenRouterImageApiService service)
    {
        _service = service;
    }
    
    public override HttpClient GetHttpClient()
        => _service.HttpClient;
    
    public override async Task<List<GenerateImageResponse>> Generate(GenerateImageRequest prompt)
    {
        var modelType = Constants.OpenRouterImageModelList.Models.FirstOrDefault(x => x.ModelApiName == prompt.ModelName);
        if(modelType == null)
            modelType = Constants.OpenRouterImageModelList.Models.FirstOrDefault();
        
        var request = new
        {
            model = modelType.ModelApiName,
            modalities = new List<string>(){ "image"},
            input = new[]
            {
                new
                {
                    role = "user", 
                    content = prompt.Prompt
                }
            },
            image_config = new
            {
                aspect_ratio = prompt.ImageSize.ToDefaultAspectRatio(),
                image_size = prompt.Quality == ImageGenerationQuality.High ? "4K" : "2K",
            },
        };
       
        var result = new List<GenerateImageResponse>();
        var response = await _service.GenerateImage(request);
        var tempFolder = StorageManager.Instance.GetTempFolder();
        
        foreach (var imageData in response.output)
        {
            var imagePath = tempFolder.GetPathForFile($"{IdHelper.GetId()}.png");
            
            var base64 = imageData.result;
            if (base64.Contains(','))
                base64 = base64.Split(',')[1];

            await File.WriteAllBytesAsync(imagePath, Convert.FromBase64String(base64));
            result.Add(new()
            {
                Size = prompt.ImageSize,
                Provider = ImageGenProvider.OpenAI,
                LocalFilePath = imagePath,
                ModelName = modelType.ModelApiName,
            });
        }
        
        return result;
    }

}