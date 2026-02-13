using Aco228.AIGen.Grok.Models;
using Aco228.AIGen.Grok.Models.Images;
using Aco228.AIGen.Grok.Services.Web;
using Aco228.AIGen.Models;
using Aco228.AIGen.Services;
using Aco228.Common.Extensions;

namespace Aco228.AIGen.Grok.Services;

public interface IGrokImageGen : IImgGen
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
        var modelType = prompt.ModelName.ToEnumNull<GrokImageModelType>();
        if (modelType == null)
            throw new ArgumentException("Invalid model name");
        
        var stringSize = prompt.ImageSize.ToDefaultAspectRatio();
        
        var request = new ImageRequest()
        {
            prompt = prompt.Prompt,
            model = ModelTypeHelper.GetModelApiName(modelType.Value),
            aspect_ratio = stringSize,
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