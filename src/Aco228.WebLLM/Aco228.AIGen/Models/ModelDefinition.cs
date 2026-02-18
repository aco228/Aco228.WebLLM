namespace Aco228.AIGen.Models;


public class ModelDefinition
{
    public required TextGenProvider Provider { get; set; }
    public required PriceLevel PriceLevel { get; set; }
    public required ModelTier Tier { get; set; }
    public required string Name { get; set; }
    public required string ModelApiName { get; set; }
    public string? Description { get; set; }
    public uint ContextWindow { get; set; }
    public required bool IsVisionSupported { get; set; }
    public required bool IsImageOutputSupported { get; set; }
    
    public required double InputPricePerMillion { get; set; }
    public required double OutputPricePerMillion { get; set; }
}