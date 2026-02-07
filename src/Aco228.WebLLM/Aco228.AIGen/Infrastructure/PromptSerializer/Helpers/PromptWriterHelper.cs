using Aco228.AIGen.Models;

namespace Aco228.AIGen.Infrastructure.PromptSerializer.Helpers;

internal static class PromptWriterHelper
{
    
    public static string AppendHeader(this string input, string headerName)
        => input + Environment.NewLine + $"## {headerName}" + Environment.NewLine;

    public static string AppendString(this string input, string headerName, string? value)
    {
        if(string.IsNullOrEmpty(value)) return input;
        return input.AppendHeader(headerName) + value + Environment.NewLine;
    }

    public static string AppendSections(this string input, List<PromptSection> sections)
    {
        foreach (var promptSection in sections)
            input = input.AppendList(promptSection.Name, promptSection.Lines);
        return input;
    }
    

    public static string AppendList(this string input, string name,  List<string> list)
    {
        if (!list.Any()) return input;
        return input.AppendHeader(name) + string.Join(Environment.NewLine, list.Select(x => $"- {x}")) + Environment.NewLine;
    }
    
}