namespace Aco228.AIGen.Attributes;

public class PromptHintAttribute : Attribute
{
    public string[] Value { get; set; }
    
    public string GetValue()
        => string.Join(", ", Value);

    public PromptHintAttribute(params string[] value)
    {
        Value = value;
    }
}