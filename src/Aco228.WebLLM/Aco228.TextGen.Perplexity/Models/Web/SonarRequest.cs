namespace Aco228.TextGen.Perplexity.Models.Web;

public class SonarRequest
{
    public string model { get; set; } = "sonar-pro";
    public List<SonarRequestMessage> messages { get; set; } = new();
    public bool stream { get; set; } = false;
}

public class SonarRequestMessage
{
    public string role { get; set; } = "user";
    public string content { get; set; }
}