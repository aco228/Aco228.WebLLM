using Aco228.AIGen.Models;

namespace Aco228.AIGen.ChatGPT.Models;

public enum ChatGptModelType
{
    [ModelType("gpt-5.2")]
    GPT5_2,
    
    [ModelType("gpt-5.1")]
    GPT5_1,
    
    [ModelType("gpt-5")]
    GPT5,
    
    [ModelType("gpt-5-mini")]
    GPT5_MINI,
    
    [ModelType("gpt-5-nano")]
    GPT5_NANO,
}