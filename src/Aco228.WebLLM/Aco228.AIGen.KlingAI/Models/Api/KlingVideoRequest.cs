namespace Aco228.AIGen.KlingAI.Models.Api;

public class KlingVideoRequest
{
    public string model_name { get; set; } = "kling-v2-6";
    public required string prompt { get; set; }
    public string negative_prompt { get; set; } = "";
    public int duration { get; set; } = 5;
    public string mode { get; set; } = "pro"; // std
    public string sound { get; set; } = "on";
    public string aspect_ratio { get; set; } = "9:16";
    public string callback_url { get; set; }
    public string external_task_id { get; set; }
}
