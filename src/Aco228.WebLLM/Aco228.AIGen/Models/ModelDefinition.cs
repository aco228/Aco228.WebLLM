namespace Aco228.AIGen.Models;


public class ModelDefinition
{
    public TextGenProvider Provider { get; set; }
    public ModelLevel Level { get; set; }
    public string Name { get; set; }
    public string ModelApiName { get; set; }
    
    public double InputPricePerMillion { get; set; }
    public double OutputPricePerMillion { get; set; }
}