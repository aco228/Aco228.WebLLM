namespace Aco228.AIGen.Models;

public class TextGenerationRequest
{
    public TextGenProvider? Type { get; set; }
    public ModelDefinition? Model { get; set; }
    public string User { get; set; }
    public string? System { get; set; }
    public List<string> ImageUrls { get; set; } = new();

    public TextGenerationRequest() { }

    public TextGenerationRequest(string userUser)
    {
        User = userUser;
    }

    public TextGenerationRequest(string system, string user) : this(user)
    {
        User = user;
    }

    public TextGenerationRequest(TextGenProvider type, string system, string user) : this(system, user)
    {
        Type = type;
    }
    
}