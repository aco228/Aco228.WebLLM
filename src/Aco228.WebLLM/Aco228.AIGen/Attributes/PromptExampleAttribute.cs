namespace Aco228.AIGen.Attributes;

public class PromptExampleAttribute : Attribute
{
    public object[] Value { get; set; }

    public PromptExampleAttribute(params object[] values)
    {
        Value = values;
    }
}