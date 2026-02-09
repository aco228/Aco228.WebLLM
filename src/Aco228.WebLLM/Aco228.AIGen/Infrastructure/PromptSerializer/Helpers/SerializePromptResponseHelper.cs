using System.Reflection;
using System.Text;
using System.Text.Json;
using Aco228.AIGen.Attributes;
using Aco228.Common.Extensions;
using Aco228.Common.Models;
using MongoDB.Bson;

namespace Aco228.AIGen.Infrastructure.PromptSerializer.Helpers;

internal class SerializePromptResponseHelper<TRes>
{
    private static List<Type> ForbiddenTypes = new()
    {
        typeof(ObjectId),
    };

    public static List<string> ForbiddenNames => new()
    {
        "CreatedUtc", "UpdatedUtc"
    };

    private static List<string> Guidelines = new()
    {
        "If array is specified in scheme, use array even if there is only one value",
        "If example scheme contains null for property, only then use null",
        "Use strings, arrays, or null as appropriate",
        "Valid JSON",
        "No explanations outside JSON",
        "Output must strictly conform to schema or is invalid.",
    };

    private record ClassProperty(string Name, TypeDeconstructor Type, PromptHintAttribute? HintAttribute);
    private Dictionary<ClassProperty, List<ClassProperty>> Structure = new();
    
    public StringBuilder Serialize()
    {
        var result = new StringBuilder();
        var responseType = typeof(TRes);
        var typeDefinition = TypeDeconstructor.Get(responseType);
        var guidelines = new List<string>(Guidelines);
        string? jsonRepresentation = null;

        if (typeDefinition.IsClass)
        {
            object? obj = null;
            if (typeDefinition.IsList)
            {
                var (list, initialObject) = CreateDummyList(typeDefinition);
                obj = list;
            }
            else if (typeDefinition.IsClass)
                obj = Activator.CreateInstance(typeof(TRes));

            if (obj == null)
                throw new Exception("Unable to create object of type " + responseType);
        
            var classProperty = new ClassProperty("", typeDefinition, null);
            DummyPopulate(obj, classProperty);
            
            jsonRepresentation = JsonSerializer.Serialize(obj, new JsonSerializerOptions() { WriteIndented = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
        }
        else
            guidelines.Clear();
        
        
        result
            .AppendString("Schema properties", ConstructPropertyHints())
            .AppendList("Guidelines", guidelines)
            .AppendString("JSON format you must return", jsonRepresentation);
        
        return result;
    }

    private string ConstructPropertyHints()
    {
        var sb = new StringBuilder();
        foreach (var (key, types) in Structure.Reverse())
        {
            var typeCandidates = types.Where(x => x.HintAttribute != null).ToList();
            if (typeCandidates.Any() == false)
                continue;

            var sectionName = string.IsNullOrEmpty(key.Name)
                ? $"## Root level properties ({key.Type.GetJsonObjectDefinition()})"
                : $"## {key.Name.ToCamelCase()} ({key.Type.GetJsonObjectDefinition()})";
            
            sb.AppendLine($"{sectionName} {key.HintAttribute?.GetValue()}");
            if(key.Type.IsList)
                sb.AppendLine("Create one set of properties for each item in the array.");
            
            foreach (var classProperty in typeCandidates)
            {
                var propertyType = classProperty.Type.IsClass ? "object" : classProperty.Type.Type.Name.ToLowerInvariant();
                if (classProperty.Type.IsList) propertyType += " array";
            
                sb.AppendLine($"- *{classProperty.Name.ToCamelCase()}* ({propertyType}): {classProperty.HintAttribute!.GetValue()}");   
            }
            sb.AppendLine();
        }

        return sb.ToString();
    }
    
    private void DummyPopulate(object inputObject, ClassProperty inputClassProperty)
    {
        var deconstructorTypes = new List<ClassProperty>();
        var typeDeconstructor = TypeDeconstructor.Get(inputObject.GetType());
        
        object? obj = typeDeconstructor.IsList
            ? (object) (((dynamic) inputObject)[0])
            : inputObject;
        
        var props = obj.GetType().GetProperties();
        foreach (var prop in props)
        {
            if(ForbiddenTypes.Contains(prop.PropertyType))
                continue;
            
            if(ForbiddenNames.Contains(prop.Name))
                continue;
            
            var hintAttribute = prop.GetCustomAttribute<PromptHintAttribute>();
            var hintExamples = prop.GetCustomAttribute<PromptExampleAttribute>();
            var typeDefinition = TypeDeconstructor.Get(prop.PropertyType);
            var classProperty = new ClassProperty(prop.Name, typeDefinition, hintAttribute);
            
            deconstructorTypes.Add(classProperty);
            
            if (typeDefinition.IsList)
            {
                var (list, initialObject) = CreateDummyList(typeDefinition, hintExamples?.Value);

                if (typeDefinition.IsClass)
                    DummyPopulate(initialObject, classProperty);
                
                prop.SetValue(obj, list);
            }
            else if (typeDefinition.IsClass)
            {
                var classValue = Activator.CreateInstance(prop.PropertyType)!;
                
                if(typeDefinition.IsClass)
                    DummyPopulate(classValue, classProperty);
                
                
                prop.SetValue(obj, classValue);
            }

            if (prop.PropertyType == typeof(string))
                prop.SetValue(obj, hintExamples?.Value.FirstOrDefault() ?? "");
        }
        
        if(!Structure.Any(x => x.Key.Name == inputClassProperty.Name))
            Structure.Add(inputClassProperty, deconstructorTypes);
    }

    private static Tuple<object, object> CreateDummyList(TypeDeconstructor typeDefinition, object[]? insertData = null)
    {
        var listType = typeof(List<>).MakeGenericType(typeDefinition.Type);
        var list = Activator.CreateInstance(listType);
        if (list == null)
            throw new Exception("Unable to create list of type " + typeDefinition.Type);
        
        var addMethod = listType.GetMethod("Add");
        var initialObject = typeDefinition.Type == typeof(string) ? "" : 
            Activator.CreateInstance(typeDefinition.Type);

        if (insertData == null || insertData?.Any() == false)
        {
            if (initialObject == null)
                throw new Exception("Unable to create object of type " + typeDefinition.Type);

            addMethod?.Invoke(list, new [] { initialObject });
        }
        else
        {
            initialObject = insertData!.First();
            foreach (var item in insertData!)
                addMethod?.Invoke(list, new [] { item });
        }
        
        return new (list, initialObject);
    }
}