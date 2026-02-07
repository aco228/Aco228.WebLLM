using System.Text;
using Aco228.Common.Helpers;

namespace Aco228.AIGen.Infrastructure.PromptSerializer;

internal static class PromptTextsProvider
{

    public static async Task<StringBuilder> GetPromptText(string promptName)
    {
        var fileInfo = AssemblyFileLocator.AssemblyFiles.FirstOrDefault(x => x.Name.StartsWith(promptName));
        if (fileInfo == null)
            throw new Exception($"Prompt {promptName} not found");
        
        var text = await File.ReadAllTextAsync(fileInfo.FullName);
        return new StringBuilder(text);
    }
}