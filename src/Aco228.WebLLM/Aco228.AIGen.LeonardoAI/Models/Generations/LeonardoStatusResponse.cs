using System.Text.Json.Serialization;

namespace Aco228.AIGen.LeonardoAI.Models.Generations;

public class LeonardoStatusResponse
{
    [JsonPropertyName("generations_by_pk")]
    public LeonardoGenerationsByPkDTO Job { get; set; }
}


public class LeonardoGeneratedImageDTO
{
    public string url { get; set; }
    public bool nsfw { get; set; }
    public string id { get; set; }
    public int likeCount { get; set; }
    public object motionMP4URL { get; set; }
    public List<object> generated_image_variation_generics { get; set; }
}


public class LeonardoPromptModerationDTO
{
    public List<string> moderationClassification { get; set; }
}

public class LeonardoGenerationsByPkDTO
{
    public List<LeonardoGeneratedImageDTO> generated_images { get; set; }
    public string modelId { get; set; }
    public object motion { get; set; }
    public object motionModel { get; set; }
    public object motionStrength { get; set; }
    public string prompt { get; set; }
    public string negativePrompt { get; set; }
    public int imageHeight { get; set; }
    public object imageToVideo { get; set; }
    public int imageWidth { get; set; }
    public int inferenceSteps { get; set; }
    public int seed { get; set; }
    public bool ultra { get; set; }
    [JsonPropertyName("public")]
    public bool Public { get; set; }
    public string scheduler { get; set; }
    public string sdVersion { get; set; }
    public string status { get; set; }
    public object presetStyle { get; set; }
    public object initStrength { get; set; }
    public int guidanceScale { get; set; }
    public string id { get; set; }
    public string createdAt { get; set; }
    public bool promptMagic { get; set; }
    public object promptMagicVersion { get; set; }
    public object promptMagicStrength { get; set; }
    public bool photoReal { get; set; }
    public object photoRealStrength { get; set; }
    public object fantasyAvatar { get; set; }
    public List<LeonardoPromptModerationDTO> prompt_moderations { get; set; }
}
