using Aco228.AIGen.Models;

namespace Aco228.AIGen.ChatGPT.Models;

public enum ChatGptImageModelType
{
    [ModelType("gpt4o")]
    gpt4o,
    gpt1,
    gpt1_5,
    gpt_image_1mini,
    chatgpt_image_latest,
}