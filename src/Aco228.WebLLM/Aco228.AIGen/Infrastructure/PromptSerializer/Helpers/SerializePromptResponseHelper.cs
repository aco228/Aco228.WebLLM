using System.Reflection;
using System.Text.Json;
using Aco228.AIGen.Attributes;
using Aco228.Common.Extensions;
using Aco228.Common.Models;

namespace Aco228.AIGen.Infrastructure.PromptSerializer.Helpers;

internal class SerializePromptResponseHelper<TRes>
{
    private record ClassProperty(string Name, TypeDeconstructor Type, PromptHintAttribute? HintAttribute);
    
    private Dictionary<string, ClassProperty> _usedTypes = new();

    private static List<string> Guidelines = new()
    {
        "If array is specified in scheme, use array even if there is only one value",
        "If example scheme contains null for property, only then use null",
        "Use strings, arrays, or null as appropriate",
        "Valid JSON",
        "No explanations outside JSON",
        "Output must strictly conform to schema or is invalid.",
    };

    
    public SerializePromptResponseHelper()
    {
        
    }
    
    
    public string Serialize(
        List<string>? additionalGuidelines = null)
    {
        var responseType = typeof(TRes);
        var typeDefinition = TypeDeconstructor.Get(responseType);
        var guidelines = new List<string>();
        string? jsonRepresentation = null;

        if (responseType.IsClassObject())
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
        
            DummyPopulate(obj);
            
            jsonRepresentation = JsonSerializer.Serialize(obj, new JsonSerializerOptions() { WriteIndented = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
        }
        else
            guidelines.Clear();
        
        guidelines = guidelines.GetAddRange(additionalGuidelines);
        
        string result = ""
            .AppendList("Guidelines", guidelines)
            .AppendList("Schema properties", ConstructPropertyHints())
            .AppendString("Example schema", jsonRepresentation);
        
        return result;
    }

    private List<string> ConstructPropertyHints()
    {
        var guidelines = new List<string>();
        foreach (var (_, classProperty) in _usedTypes)
        {
            if (classProperty.HintAttribute == null) continue;
            
            var propertyType = classProperty.Type.IsClass ? "" : classProperty.Type.Type.Name.ToLowerInvariant();
            if (classProperty.Type.IsList) propertyType += " array";
            
            guidelines.Add($"({propertyType}) {classProperty.Name.ToCamelCase()} = {classProperty.HintAttribute.GetValue()}");
        }

        return guidelines;
    }
    
    private void DummyPopulate(object inputObject)
    {
        var typeDeconstructor = TypeDeconstructor.Get(inputObject.GetType());
        
        object? obj = typeDeconstructor.IsList
            ? (object) (((dynamic) inputObject)[0])
            : inputObject;
        
        var props = obj.GetType().GetProperties();
        foreach (var prop in props)
        {
            var hintAttribute = prop.GetCustomAttribute<PromptHintAttribute>();
            var hintExamples = prop.GetCustomAttribute<PromptExampleAttribute>();
            var typeDefinition = TypeDeconstructor.Get(prop.PropertyType);
            _usedTypes.TryAdd(prop.Name, new(prop.Name, typeDefinition, hintAttribute));
            
            if (typeDefinition.IsList)
            {
                var (list, initialObject) = CreateDummyList(typeDefinition, hintExamples?.Value);

                if (typeDefinition.IsClass)
                    DummyPopulate(initialObject);
                
                prop.SetValue(obj, list);
            }
            else if (typeDefinition.IsClass)
            {
                var classValue = Activator.CreateInstance(prop.PropertyType)!;
                
                if(typeDefinition.IsClass)
                    DummyPopulate(classValue);
                
                prop.SetValue(obj, classValue);
            }

            if (prop.PropertyType == typeof(string))
                prop.SetValue(obj, hintExamples?.Value.FirstOrDefault() ?? "");
            
        }
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