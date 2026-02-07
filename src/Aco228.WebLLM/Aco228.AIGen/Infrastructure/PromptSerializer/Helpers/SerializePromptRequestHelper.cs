using System.Collections;
using System.Reflection;
using Aco228.AIGen.Attributes;

namespace Aco228.AIGen.Infrastructure.PromptSerializer.Helpers;

internal static class SerializePromptRequestHelper
{
    public static string SerializeToString<TReq>(TReq input)
    {
        var list = SerializeToList(input);
        var result = string.Join(Environment.NewLine, list);
        return result;
    }
    
    public static List<string> SerializeToList<TReq>(TReq input)
    {
        var result = new List<string>();
        var props = input!.GetType().GetProperties();

        foreach (var prop in props)
        {
            var propValue = prop.GetValue(input);
            if (propValue == null) 
                continue;
            
            var propStringValue = propValue is not string && propValue is IEnumerable enumerable 
                ? string.Join(", ", enumerable.Cast<object>())
                : propValue.ToString() ?? string.Empty;
            
            if(string.IsNullOrEmpty(propStringValue)) 
                continue;
            
            var promptHint = prop.GetCustomAttribute<PromptHintAttribute>();
            var promptIgnoreAttribute = prop.GetCustomAttribute<PromptIgnoreAttribute>();
            var promptFileIdAttribute = prop.GetCustomAttribute<PromptFileIdAttribute>();

            if (promptIgnoreAttribute != null || promptFileIdAttribute != null)
                continue;
            
            var propName = prop.Name;
            
            if (promptHint != null && promptHint.Value.Any())
                propName = string.Join(" ", promptHint.Value);
            
            result.Add($"{propName} = {propStringValue}");
        }

        return result;
    }
}