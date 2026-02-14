using Aco228.AIGen.Grok.Models;
using Aco228.AIGen.Grok.Models.Images;
using Aco228.AIGen.Grok.Services.Web;
using Aco228.AIGen.Models;
using Aco228.AIGen.Services;
using Aco228.Common.Extensions;
using Aco228.Common.Models;

namespace Aco228.AIGen.Grok.Services;

public interface IGrokImageGen : IImgGen, ITransient
{
}

public class GrokImageGen : ImgGen, IGrokImageGen
{
    private readonly IGrokImageApiService _service;

    public GrokImageGen(IGrokImageApiService service)
    {
        _service = service;
    }

    public override async Task<List<GenerateImageResponse>> Generate(GenerateImageRequest prompt)
    {
        var modelType = Constants.GrokImageModelList.Models.FirstOrDefault(x => x.ModelApiName == prompt.ModelName);
        if (modelType == null)
            throw new ArgumentException("Invalid model name");
        
        var stringSize = prompt.ImageSize.ToDefaultAspectRatio();
        
        var request = new ImageRequest()
        {
            prompt = prompt.Prompt,
            model = modelType.ModelApiName,
            aspect_ratio = stringSize,
            n = prompt.Count,
        };

        var apiResponse = await _service.GenerateImage(request);
        var result = new List<GenerateImageResponse>();

        foreach (var res in apiResponse.data)
        {
            result.Add(new()
            {
                Size = prompt.ImageSize,
                Provider = ImageGenProvider.Grok,
                ImageUrl = res.url
            });
        }

        return result;
    }
}