using System.Text;
using Aco228.AIGen.Models;

namespace Aco228.AIGen.Infrastructure.PromptSerializer.Helpers;

internal static class PromptWriterHelper
{
    
    public static StringBuilder AppendHeader(this StringBuilder input, string headerName)
        => input
            .Append(Environment.NewLine)
            .Append($"## {headerName}")
            .Append(Environment.NewLine);

    public static StringBuilder AppendString(this StringBuilder input, string headerName, string? value)
    {
        if(string.IsNullOrEmpty(value)) return input;
        return input
            .AppendHeader(headerName)
            .AppendLine(value);
    }

    public static StringBuilder AppendSections(this StringBuilder input, List<PromptSection> sections)
    {
        if (!sections.Any()) return input;
        
        foreach (var promptSection in sections)
            input.AppendList(promptSection.Name, promptSection.Lines);
        
        return input;
    }
    

    public static StringBuilder AppendList(this StringBuilder input, string name,  List<string> list)
    {
        if (!list.Any()) return input;

        input.AppendHeader(name);
            
        foreach (var entry in list)
            input.AppendLine($"- {entry}");

        return input;
    }
    
}