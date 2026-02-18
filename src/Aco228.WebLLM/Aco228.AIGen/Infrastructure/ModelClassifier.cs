using Aco228.AIGen.Models;

namespace Aco228.AIGen.Infrastructure;


public static class ModelClassifier
{
    private static readonly Dictionary<string, ModelTier> Overrides = new(StringComparer.OrdinalIgnoreCase)
    {
        { "deepseek/deepseek-chat",           ModelTier.High },
        { "deepseek/deepseek-r1",             ModelTier.High },
    };

    private static readonly string[] HighTerms = 
    { 
        "sonnet", "opus", "gpt-4o", "gpt-4", "ultra", "large",
        "405b", "70b", "72b", "heavy", "max", 
    };

    private static readonly string[] LowTerms  = 
    { 
        "mini", "micro", "flash", "haiku", "lite",
        "small", "3b", "7b", "8b", "nano", "tiny" 
    };

    public static ModelTier Classify(ModelDefinition model)
    {
        if (Overrides.TryGetValue(model.ModelApiName, out var overrideTier))
            return overrideTier;

        int score = 0;
        string name = model.ModelApiName.ToLowerInvariant();

        if (model.PriceLevel == PriceLevel.High) score += 2;
        if (model.PriceLevel == PriceLevel.Mid) score += 1;

        foreach (var term in HighTerms)
            if (name.Contains(term)) { score += 3; break; }

        foreach (var term in LowTerms)
            if (name.Contains(term)) { score -= 3; break; }
        
        if(model.ContextWindow > 900000) score += 1;
        if(model.IsVisionSupported) score += 1;

        return score >= 4 ? ModelTier.High
            : score >= 1 ? ModelTier.Mid
            :               ModelTier.Low;
    }
}