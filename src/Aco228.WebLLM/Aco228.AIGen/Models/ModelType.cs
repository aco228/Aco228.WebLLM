using System.Reflection;

namespace Aco228.AIGen.Models;

[AttributeUsage(AttributeTargets.Field)]
public class ModelTypeAttribute : Attribute
{
    public string Name { get; set; }

    public ModelTypeAttribute(string name)
    {
        Name = name;
    }
}

public static class ModelTypeHelper
{
    public static string GetModelApiName(Enum value)
    {
        var type = value.GetType();
        var member = type.GetMember(value.ToString());
        if (!member.Any())
            throw new InvalidOperationException(@"Missing enum value");

        var attr = member.First().GetCustomAttribute<ModelTypeAttribute>();
        if (attr == null)
            throw new InvalidOperationException(@"Model member missing attribute");
        
        return attr.Name;
    }
}