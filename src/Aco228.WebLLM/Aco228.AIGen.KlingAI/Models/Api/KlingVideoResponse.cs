namespace Aco228.AIGen.KlingAI.Models.Api;

public class KlingVideoResponse
{
    public int code { get; set; }
    public string message { get; set; }
    public string request_id { get; set; }
    public KlingVideoResponseDataDTO data { get; set; }
}

public class KlingVideoResponseTaskInfoDTO
{
    public string external_task_id { get; set; }
}

public class KlingVideoResponseDataDTO
{
    public string task_id { get; set; }
    public KlingVideoResponseTaskInfoDTO task_info { get; set; }
    public string task_status { get; set; }
    public long created_at { get; set; }
    public long updated_at { get; set; }
}
