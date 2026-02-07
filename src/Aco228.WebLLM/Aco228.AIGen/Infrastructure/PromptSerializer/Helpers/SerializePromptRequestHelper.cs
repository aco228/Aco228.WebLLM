using System.Collections;
using System.Reflection;
using System.Text;
using Aco228.AIGen.Attributes;

namespace Aco228.AIGen.Infrastructure.PromptSerializer.Helpers;

internal static class SerializePromptRequestHelper
{
    public static StringBuilder SerializeToString<TReq>(TReq input)
    {
        var result = SerializeToList(input);
        return result;
    }
    
    public static StringBuilder SerializeToList<TReq>(TReq input)
    {
        var result = new StringBuilder();
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
            var promptFileIdAttribute = prop.GetCustomAttribute<PromptImageUrlAttribute>();

            if (promptIgnoreAttribute != null || promptFileIdAttribute != null)
                continue;
            
            var propName = prop.Name;
            
            if (promptHint != null && promptHint.Value.Any())
                propName = string.Join(" ", promptHint.Value);

            result.AppendLine($"{propName} = {propStringValue}");
        }

        return result;
    }
}