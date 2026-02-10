using Aco228.AIGen.ChatGPT.Models.Web.Images;
using Aco228.AIGen.ChatGPT.Services.Web;
using Aco228.Common.Helpers;
using Aco228.Common.LocalStorage;
using Aco228.Common.Models;

namespace Aco228.AIGen.ChatGPT.Services;

public interface IChatgptImageGen : ITransient
{
    Task<List<FileInfo>> GenerateImage(string prompt, int count = 1);
}

public class ChatgptImageGen : IChatgptImageGen
{
    private readonly IChatgptImageApiService _apiService;

    public ChatgptImageGen(IChatgptImageApiService apiService)
    {
        _apiService = apiService;
    }
    
    public async Task<List<FileInfo>> GenerateImage(string prompt, int count = 1)
    {
        var request = new GenerateImageRequest()
        {
            prompt = prompt,
            Count = count,
        };
        
        var result = new List<FileInfo>();
        var response = await _apiService.GenerateImage(request);
        var tempFolder = StorageManager.Instance.GetTempFolder();
        
        foreach (var imageData in response.data)
        {
            var imagePath = tempFolder.GetPathForFile($"{IdHelper.GetId()}.png");
            await File.WriteAllBytesAsync(imagePath, Convert.FromBase64String(imageData.b64_json));
            result.Add(new FileInfo(imagePath));
        }

        return result;
    }
}