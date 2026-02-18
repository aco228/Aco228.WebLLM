namespace Aco228.AIGen.Models;

public class ModelImageDefinition
{
    public ImageGenProvider Provider { get; set; }
    public PriceLevel PriceLevel { get; set; }
    public ModelTier Tier { get; set; }
    public string Name { get; set; }
    public string ModelApiName { get; set; }
    
    public double PricePerRequest { get; set; }

    public ModelImageDefinition() {}

    public ModelImageDefinition(ImageGenProvider provider) : this()
    {
        Provider = provider;
    }
}