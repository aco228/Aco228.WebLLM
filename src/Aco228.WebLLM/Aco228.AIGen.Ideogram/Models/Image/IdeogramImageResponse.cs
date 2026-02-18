namespace Aco228.AIGen.Ideogram.Models.Image;

public class IdeogramImageResponse
{
    public DateTime created { get; set; }
    public List<IdeogramImageResponseData> data { get; set; }
}

public class IdeogramImageResponseData
{
    public string prompt { get; set; }
    public string resolution { get; set; }
    public string url { get; set; }
}