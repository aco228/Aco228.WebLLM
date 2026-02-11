using Aco228.AIGen.Models;

namespace Aco228.TextGen.Claude.Models;

public enum ClaudeModelType
{
    [ModelType("claude-opus-4-6")]
    ClaudeOpus4_6,
    
    [ModelType("claude-sonnet-4-5-20250929")]
    ClaudeSonnet4_5,
    
    [ModelType("claude-haiku-4-5-20251001")]
    ClaudeHaiku4_5,
}