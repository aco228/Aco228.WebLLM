namespace Aco228.AIGen.KlingAI.Models.Api;

public class KlingStatusResponse
{
    public int code { get; set; }
    public string message { get; set; }
    public string request_id { get; set; }
    public DataDTO? data { get; set; }
}


public class KlingStatusResponseWatermarkInfoDTO
{
    public bool enabled { get; set; }
}

public class KlingStatusResponseTaskInfoDTO
{
    public string external_task_id { get; set; }
}

public class KlingStatusResponseVideoDTO
{
    public string id { get; set; }
    public string url { get; set; }
    public string watermark_url { get; set; }
    public string duration { get; set; }
}

public class KlingStatusResponseTaskResultDTO
{
    public List<KlingStatusResponseVideoDTO> videos { get; set; }
}

public class DataDTO
{
    public string task_id { get; set; }
    public string task_status { get; set; }
    public string task_status_msg { get; set; }
    public string final_unit_deduction { get; set; }
    public KlingStatusResponseWatermarkInfoDTO watermark_info { get; set; }
    public KlingStatusResponseTaskInfoDTO task_info { get; set; }
    public KlingStatusResponseTaskResultDTO? task_result { get; set; }
    public long created_at { get; set; }
    public long updated_at { get; set; }
}
