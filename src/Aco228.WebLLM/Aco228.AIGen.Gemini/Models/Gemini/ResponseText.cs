namespace Aco228.AIGen.Gemini.Models.Gemini;

public class ResponseText
{
    public List<CandidateDTO> candidates { get; set; }
    public UsagemetadataDTO usageMetadata { get; set; }
    public string modelVersion { get; set; }
    public string createTime { get; set; }
    public string responseId { get; set; }
}

public class PartDTO
{
    public string text { get; set; }
}

public class ContentDTO
{
    public string role { get; set; }
    public List<PartDTO> parts { get; set; }
}

public class CandidateDTO
{
    public ContentDTO content { get; set; }
}

public class UsagemetadataDTO
{
    public int promptTokenCount { get; set; }
    public int candidatesTokenCount { get; set; }
    public string trafficType { get; set; }
}
