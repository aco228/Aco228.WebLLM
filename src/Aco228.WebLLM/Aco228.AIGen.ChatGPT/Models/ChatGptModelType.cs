using Aco228.AIGen.Models;

namespace Aco228.AIGen.ChatGPT.Models;

public enum ChatGptModelType
{
    [ModelType("gpt-5.4")]
    GptPro,
    
    [ModelType("gpt-5.4-mini")]
    GptMini,
    
    [ModelType("gpt-5.4-nano")]
    GptNano,
    
}