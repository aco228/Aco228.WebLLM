namespace Aco228.AIGen.Models;


public class ModelDefinition
{
    public TextGenProvider Provider { get; set; }
    public PriceLevel PriceLevel { get; set; }
    public ModelTier Tier { get; set; }
    public string Name { get; set; }
    public string ModelApiName { get; set; }
    public string? Description { get; set; }
    public uint ContextWindow { get; set; }
    public bool IsVisionSupported { get; set; }
    public bool IsImageOutputSupported { get; set; }
    
    public double InputPricePerMillion { get; set; }
    public double OutputPricePerMillion { get; set; }
}