namespace Aco228.AIGen.Models;

public class GenerateImageRequest
{
    public required string Prompt { get; set; }
    public ImageGenType? Type { get; set; }
    public ImageGenProvider? Provider { get; set; }
    public int Count { get; set; } = 1;
    public ImageSize ImageSize { get; set; } = ImageSize.Square;
}

public class GenerateImageResponse
{
    public required ImageGenProvider Provider { get; set; }
    public string? ImageUrl { get; set; }
    public string? TaskId { get; set; }
}