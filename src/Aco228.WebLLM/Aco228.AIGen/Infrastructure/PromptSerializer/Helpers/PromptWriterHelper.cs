namespace Aco228.AIGen.Infrastructure.PromptSerializer.Helpers;

internal static class PromptWriterHelper
{
    
    public static string AppendHeader(this string input, string headerName)
        => input + Environment.NewLine + $"## {headerName}" + Environment.NewLine;
    
    public static string AppendString(this string input, string headerName, string value)
        => input.AppendHeader(headerName) + value + Environment.NewLine;

    public static string AppendList(this string input, string name,  List<string> list)
    {
        if (!list.Any()) return input;
        return input.AppendHeader(name) + string.Join(Environment.NewLine, list.Select(x => $"- {x}")) + Environment.NewLine;
    }
    
}