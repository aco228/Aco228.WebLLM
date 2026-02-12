using Aco228.AIGen.Models;

namespace Aco228.AIGen.Services;

public interface IImgGen
{
    Task<List<GenerateImageResponse>> Generate(GenerateImageRequest prompt);
}

public abstract class ImgGen : IImgGen
{
    public abstract Task<List<GenerateImageResponse>> Generate(GenerateImageRequest prompt);
}