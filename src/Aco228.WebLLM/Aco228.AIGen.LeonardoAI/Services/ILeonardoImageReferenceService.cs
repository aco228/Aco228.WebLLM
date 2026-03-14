using System.Net.Http.Headers;
using System.Text.Json;
using Aco228.AIGen.LeonardoAI.Models;
using Aco228.AIGen.LeonardoAI.Models.Generations;
using Aco228.AIGen.LeonardoAI.Services.Api;
using Aco228.AIGen.Models;
using Aco228.Common.Extensions;
using Aco228.Common.Models;
using Aco228.GoogleServices.Helpers;

namespace Aco228.AIGen.LeonardoAI.Services;

public interface ILeonardoImageReferenceService : ITransient
{
    Task<string> UseReferenceImage(FileInfo file, string prompt, int width, int height);
}

public class LeonardoImageReferenceService : ILeonardoImageReferenceService
{
    private readonly ILeonardoGenerationApiService _apiService;

    public LeonardoImageReferenceService(
        ILeonardoGenerationApiService apiService)
    {
        _apiService = apiService;
    }
    
    public async Task<string> UseReferenceImage(FileInfo file, string prompt, int width, int height)
    {
        var initResponse = await _apiService.UploadInitImage(new()
        {
            extension = file.Extension.Remove("."),
        });
        var uploadResult = await UploadInitImageAsync(file, initResponse);

        var generateRequest = new LeonardoGenerateRequest()
        {
            prompt = prompt,
            width = width,
            height = height,
            modelId = ModelTypeHelper.GetModelApiName(LeonardoImageModelType.LucidOrigin),
            num_images = 1,
            controlnets = new()
            {
                new()
                {
                    initImageId = uploadResult,
                    preprocessorId = LeonardoPreprocessors.StyleReference,
                }
            }
        };
        
        var response = await _apiService.Generate(generateRequest);
        return response.Job.generationId;
    }

    protected async Task<string> UploadInitImageAsync(FileInfo file, InitImageUploadResponse initResponse)
    {
        var uploadData = initResponse.uploadInitImage;
        var fields = JsonSerializer.Deserialize<Dictionary<string, string>>(uploadData.fields)!;

        using var content = new MultipartFormDataContent();

        foreach (var (key, value) in fields)
            content.Add(new StringContent(value), key);
        
        var mimeType = MimeTypeHelper.GetMimeType(file.Extension.Remove("."))!.Value;
        await using var fileStream = file.OpenRead();
        var fileContent = new StreamContent(fileStream);
        fileContent.Headers.ContentType = new MediaTypeHeaderValue(mimeType.GetMimeType());
        content.Add(fileContent, "file", file.Name);

        using var httpClient = new HttpClient();
        var response = await httpClient.PostAsync(uploadData.url, content);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception($"S3 upload failed: {response.StatusCode} - {error}");
        }

        return uploadData.id;
    }
}