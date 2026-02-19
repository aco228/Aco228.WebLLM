using Aco228.AIGen.Models;

namespace Aco228.AIGen.ChatGPT.Models;

public enum ChatGptImageModelType
{
    /// <summary>
    /// https://developers.openai.com/api/docs/models/gpt-image-1.5
    /// </summary>
    [ModelType("gpt-image-1.5")]
    gpt_image_1_5,
    
    /// <summary>
    /// https://developers.openai.com/api/docs/models/gpt-image-1
    /// </summary>
    [ModelType("gpt-image-1")]
    gpt_image_1,
    
    [ModelType("gpt-image-1-mini")]
    gpt_image_1_mini,
    
}