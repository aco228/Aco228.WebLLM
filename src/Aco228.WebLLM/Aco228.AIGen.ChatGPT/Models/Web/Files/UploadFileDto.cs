using System.Text.Json.Serialization;

namespace Aco228.AIGen.ChatGPT.Models.Web.Files;

public class UploadFileDto
{
    [JsonPropertyName("object")]
    public string Object { get; set; }
    public string id { get; set; }
    public string purpose { get; set; }
    public string filename { get; set; }
    public int bytes { get; set; }
    public int created_at { get; set; }
    public object expires_at { get; set; }
    public string status { get; set; }
    public object status_details { get; set; }
}