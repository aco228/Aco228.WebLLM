namespace Aco228.AIGen.Models.Mcp;

public class McpToolApiModel
{
    public string name { get; set; }
    public string description { get; set; }
    public McpToolApiModelInput input_schema { get; set; } = new();
}

public class McpToolApiModelInput
{
    public string type { get; set; } = "object";
    public Dictionary<string, McpToolApiModelProperties> properties { get; set; } = new();
    public List<string> required { get; set; } = new();
}

public class McpToolApiModelProperties
{
    public string type { get; set; }
    public string description { get; set; }
}