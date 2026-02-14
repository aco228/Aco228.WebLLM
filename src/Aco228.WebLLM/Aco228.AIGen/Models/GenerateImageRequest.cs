namespace Aco228.AIGen.Models;

public class GenerateImageRequest
{
    public required string Prompt { get; set; }
    public required ImageSize ImageSize { get; set; }
    
    public string? ModelName { get; set; }
    public ImageGenProvider? Provider { get; set; }
    public int Count { get; set; } = 1;
    public ImageGenerationQuality Quality { get; set; } = ImageGenerationQuality.Medium;
    public bool AsTransparent { get; set; } = false;
}

public enum ImageGenerationQuality
{
    Low,
    Medium,
    High,
}

public class GenerateImageResponse
{
    public required ImageGenProvider Provider { get; set; }
    public required ImageSize Size { get; set; }
    public string? ImageUrl { get; set; }
    public string? TaskId { get; set; }
    public string? LocalFilePath { get; set; }

}