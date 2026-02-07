using Aco228.AIGen.Attributes;
using Aco228.AIGen.Services;

namespace Aco228.TextGen.Consoler.Promts;
 
public class AdThemeGeneratorPrompt : PromptBase<PromptAdThemeGeneratorRequest, List<PromptAdThemeGeneratorResponse>>
{
    protected override string PromptName => "adThemeGenerator.v1";
}

public sealed class PromptAdThemeGeneratorRequest
{
    [PromptHint("Drawing inspiration from")]
    public List<string>? Inspiration { get; set; }
    
    [PromptHint("Follow this specific rules")] 
    public List<string>? Rules { get; set; }

    [PromptHint("Category")]
    public required string Category { get; set; }

    [PromptHint("Vertical")]
    public required string Vertical { get; set; }

    [PromptExample("Number of themes to generate: ")]
    public required int NumberOfThemes { get; set; }
}

public sealed class PromptAdThemeGeneratorResponse
{
    [PromptHint("Name of the theme. Keep it short as this will be just identifier.")] 
    [PromptExample("Hidden Gems Under $8K")]
    public string ThemeName { get; set; } 

    [PromptHint("1 sentences on the theme's core hook. Keep it shorter")]
    [PromptExample("Targets budget-conscious buyers seeking value cars...")]
    public string Summary { get; set; }

    [PromptHint("target audience segment")]
    [PromptExample("First-time car buyer (age 22-28)", "Budget-constrained families")]
    public List<string> Personas { get; set; } 

    [PromptHint("primary user intent this targets")]
    [PromptExample("Find underpriced vehicles before market corrects")]
    public string Intent { get; set; }

    [PromptHint("narrative approach or angle")]
    [PromptExample("Scarcity angle", "Smart shopper angle")]
    public List<string> Angles { get; set; }

    [PromptHint("attention-grabbing headlines or hook copy")]
    [PromptExample("Dealers hate this one simple trick...", "Why dealers won't show you these cars")]
    public List<string> Hooks { get; set; } 

    [PromptHint("recommended tone: e.g., 'aspirational', 'practical'")]
    [PromptExample("Aspirational", "practical", "insider knowledge")]
    public List<string> Tones { get; set; } 

    [PromptHint("visual directions or image descriptions")]
    [PromptExample("Before/after car transformation", "Person holding cash")]
    public List<string> ImageConcepts { get; set; } 

    [PromptHint("prohibited claims or disclaimers needed")]
    [PromptExample("No refunds", "No guarantees", "No guarantee of specific savings")]
    public List<string> AvoidClaims { get; set; }
}
