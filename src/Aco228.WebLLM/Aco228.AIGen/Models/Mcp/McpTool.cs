namespace Aco228.AIGen.Models.Mcp;

public abstract class McpTool
{
    public abstract string Name { get; }
    public abstract string Description { get; }
    public abstract McpToolApiModel GetApiModel();
}

public abstract class McpToolVoid : McpTool
{
    public abstract Task<string> GetResponse();

    public override McpToolApiModel GetApiModel()
        => new McpToolApiModel()
        {
            name = Name,
            description = Description
        };
}