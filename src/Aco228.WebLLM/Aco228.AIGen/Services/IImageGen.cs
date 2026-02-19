using Aco228.AIGen.Models;

namespace Aco228.AIGen.Services;

public interface IImageGen
{
    Task<List<GenerateImageResponse>> Generate(GenerateImageRequest prompt);
    Task<GenerateImageResponse?> GetResultFor(string taskId);
}

public abstract class ImageGen : IImageGen
{
    public abstract Task<List<GenerateImageResponse>> Generate(GenerateImageRequest prompt);
    
    
    public async Task<GenerateImageResponse?> GetResultFor(string taskId)
    {
        try
        {
            return await GetResultForInternal(taskId);
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public virtual Task<GenerateImageResponse?> GetResultForInternal(string taskId)
        => Task.FromResult<GenerateImageResponse?>(null);
}