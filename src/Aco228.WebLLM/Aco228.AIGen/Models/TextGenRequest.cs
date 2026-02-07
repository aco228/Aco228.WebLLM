namespace Aco228.AIGen.Models;

public class TextGenRequest
{
    public required string? Model { get; set; }
    public required string User { get; set; }
    public string? System { get; set; }
    public List<string>? ImageUrls { get; set; }
}