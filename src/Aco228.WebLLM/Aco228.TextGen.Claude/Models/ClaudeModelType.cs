using Aco228.AIGen.Models;

namespace Aco228.TextGen.Claude.Models;

public enum ClaudeModelType
{
    [ModelType("claude-opus-4-6")]
    ClaudeOpus,
    
    [ModelType("claude-sonnet-4-6")]
    ClaudeSonnet,
    
    [ModelType("claude-haiku-4-5-20251001")]
    ClaudeHaiku,
}