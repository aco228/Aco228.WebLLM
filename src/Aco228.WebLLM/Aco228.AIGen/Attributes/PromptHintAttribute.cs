namespace Aco228.AIGen.Attributes;

public class PromptHintAttribute : Attribute
{
    public string Value { get; set; }

    public PromptHintAttribute(string value)
    {
        Value = value;
    }
}