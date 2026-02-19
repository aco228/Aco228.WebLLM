namespace Aco228.AIGen.Models;

public class ImageGenerateSpecifications
{
    public ImageSize Size { get; set; } = ImageSize.Square;
    public ImageGenerationQuality Quality { get; set; } = ImageGenerationQuality.Medium;
    public PriceLevel ModelPriceLevel { get; set; } = PriceLevel.Low;
    public List<string> Rules { get; set; } = new();

    public List<ImageGenProvider> Providers { get; set; } = new();
}