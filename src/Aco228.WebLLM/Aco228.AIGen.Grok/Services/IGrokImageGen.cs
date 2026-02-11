using Aco228.AIGen.Grok.Models;
using Aco228.AIGen.Grok.Models.Images;
using Aco228.AIGen.Grok.Services.Web;
using Aco228.AIGen.Models;

namespace Aco228.AIGen.Grok.Services;

public interface IGrokImageGen
{
    Task<List<GenerateImageResponse>> Generate(GenerateImageRequest prompt);
}

public class GrokImageGen : IGrokImageGen
{
    private readonly IGrokImageApiService _service;

    public GrokImageGen(IGrokImageApiService service)
    {
        _service = service;
    }


    public async Task<List<GenerateImageResponse>> Generate(GenerateImageRequest prompt)
    {
        string sizeString = prompt.ImageSize switch
        {
            ImageSize.Square => "1:1",
            ImageSize.Portrait => "16:9",
            ImageSize.Landscape => "9:16",
            _ => throw new ArgumentOutOfRangeException(nameof(prompt.ImageSize), prompt.ImageSize, null)
        };
        
        var request = new ImageRequest()
        {
            prompt = prompt.Prompt,
            model = prompt.Model ?? ModelTypeHelper.GetModelApiName(GrokImageModelType.GrokImagine),
            aspect_ratio = sizeString,
            n = prompt.Count,
        };

        var apiResponse = await _service.GenerateImage(request);
        var result = new List<GenerateImageResponse>();

        foreach (var res in apiResponse.data)
        {
            result.Add(new()
            {
                Provider = ImageGenProvider.Grok,
                ImageUrl = res.url
            });
        }

        return result;
    }
}