using System.Text.Json.Serialization;

namespace Aco228.AIGen.ChatGPT.Models.Web.Images;

public class GenerateImageResponse
{
    public ulong created { get; set; }
    public List<GenerateImageResponseData> data { get; set; }
    public UsageDTO usage { get; set; }
}

public class GenerateImageResponseData
{
    public string b64_json { get; set; }
}

