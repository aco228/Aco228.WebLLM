namespace Aco228.AIGen.Models;


public class ModelDefinition
{
    public TextGenProvider Provider { get; set; }
    public ModelLevel Level { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ModelApiName { get; set; }
    
    public uint MaxContextTokens { get; set; }
    public bool IsVisionSupported { get; set; }
    public bool IsFileUploadSupported { get; set; }
    public bool SupportsJson { get; set; }
    
    public int ParametersInBillions { get; set; }
    
    public double InputPricePerMillion { get; set; }
    public double OutputPricePerMillion { get; set; }
}