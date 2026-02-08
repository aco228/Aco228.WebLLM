using System.Collections;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Aco228.AIGen.Attributes;
using Aco228.Common.Extensions;
using Aco228.Common.Models;
using Aco228.Runners.Documents;

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

            if (typeof(IActionMongoModel).IsAssignableFrom(prop.PropertyType))
            {   
                var insideDocument = (propValue as IActionMongoModel)?.GetInsideDocument();
                if(insideDocument == null)
                    throw new InvalidOperationException("Unable to get inside document for IActionMongoModel");
                
                propValue = insideDocument;
                var actionMongoStringBuilder = DecompileActionMongoModel(propValue, new StringBuilder(), prop.Name);
                result.AppendLine(actionMongoStringBuilder.ToString());
                continue;
            }
            
            ExtractPropertyData(input, prop, result, prop.Name);
        }

        return result;
    }

    private static void ExtractPropertyData(object inputObject, PropertyInfo prop, StringBuilder stringBuilder, string proposedPropertyName, bool useHintAttribute = true)
    {
        var propValue = prop.GetValue(inputObject);
            
        if (propValue == null)
            return;

        var propStringValue = JsonSerializer.Serialize(propValue);
        if (string.IsNullOrEmpty(propStringValue))
            return;

        var promptHint = prop.GetCustomAttribute<PromptHintAttribute>();
        var promptIgnoreAttribute = prop.GetCustomAttribute<PromptIgnoreAttribute>();
        var jsonIgnoreAttribute = prop.GetCustomAttribute<JsonIgnoreAttribute>();
        var promptFileIdAttribute = prop.GetCustomAttribute<PromptImageUrlAttribute>();

        if (promptIgnoreAttribute != null || jsonIgnoreAttribute != null || promptFileIdAttribute != null)
            return;

        var propName = string.IsNullOrEmpty(proposedPropertyName) ? "." : "" + prop.Name;
        if (useHintAttribute && promptHint != null && promptHint.Value.Any())
            propName = string.Join(" ", promptHint.Value);

        stringBuilder.AppendLine($"{propName} = {propStringValue}");
    }

    private static StringBuilder DecompileActionMongoModel(object? inputObject, StringBuilder stringBuilder, string parentPropertyName)
    {
        if(inputObject == null) return stringBuilder;
        
        var props = inputObject.GetType().GetProperties();
        foreach (var prop in props.Where(x => x.PropertyType.IsClassObject() == false))
            ExtractPropertyData(inputObject, prop, stringBuilder, parentPropertyName, useHintAttribute: false);

        foreach (var classProps in props.Where(x => x.PropertyType.IsClassObject()))
            DecompileActionMongoModel(classProps.GetValue(inputObject), stringBuilder, $"{parentPropertyName}.{classProps.Name}");
        
        return stringBuilder;
    }
}