
using Aco228.AIGen.Models.Mcp;

namespace Aco228.TextGen.Claude.Models.Web.Text;

public class ClaudeMessageRequest
{
    public string model { get; set; }
    public uint max_tokens { get; set; } = 8000;
    public string? system { get; set; }
    public List<McpToolApiModel>? tools { get; set; }
    
    
    public List<ClaudeRequestMessage> messages { get; set; } = new();
    
    public void AddInput(string role, string content, List<string>? imageUrls = null)
    {
        var input = new ClaudeRequestMessage()
        {
            role = role,
        };
        input.content.Add(new RequestMessageEntryText(content));
        
        if(imageUrls?.Any() == true)
            foreach (var imageUrl in imageUrls)
            {
                input.content.Add(new RequestMessageEntryImage(imageUrl));
            }
        
        messages.Add(input);
    }
}

public class RequestMCPServer
{
    public string type { get; set; } = "url";
    public required string url { get; set; } 
    public required string name { get; set; } 
}

public class ClaudeRequestMessage
{
    public required string role { get; set; }
    public List<RequestMessageEntry> content { get; set; } = new();
}