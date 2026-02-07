namespace Aco228.AIGen.Models;

public class PromptSection
{
    public string Name { get; set; }
    public List<string> Lines { get; set; } = new();

    public static PromptSection Create(string name)
        => new() { Name = name };
}