namespace Aco228.AIGen.Grok.Models.Video;

public class GrokVideoStatusResponse
{
    public string status { get; set; }
    public string model { get; set; }
    public GrokVideoStatusResponseVideo? video { get; set; }
}

public class GrokVideoStatusResponseVideo
{
    public string url { get; set; }
    public int duration { get; set; }
}