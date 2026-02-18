namespace Aco228.AIGen.Models;

public class TextGenerationRequest
{
    public TextGenProvider? Provider { get; set; }
    public PriceLevel? PriceLevel { get; set; }
    public ModelTier? TierLevel { get; set; }
    public string? ModelName { get; set; }
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

    public TextGenerationRequest(TextGenProvider provider, string system, string user) : this(system, user)
    {
        Provider = provider;
    }
    
}