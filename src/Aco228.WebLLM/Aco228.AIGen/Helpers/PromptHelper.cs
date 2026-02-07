using System.Text.Json;
using System.Text.RegularExpressions;
using Aco228.AIGen.Services;
using Aco228.Common;
using Aco228.Common.Extensions;

namespace Aco228.AIGen.Helpers;

public static class PromptHelper
{
    private static readonly Regex _listRegex = new Regex(@"\[[\s\S]*\]");
    private static readonly Regex _objectRegex = new Regex(@"\{[\s\S]*\}");

    public static T Get<T>() where T : IPromptBase
        => ServiceProviderHelper.Construct<T>();
    
    
    internal static TRes? DeserializeResponse<TRes>(string llmResponse)
    {
        if (string.IsNullOrEmpty(llmResponse))
            return default;
        
        TRes? result = default;
        
        var listContent = _listRegex.Match(llmResponse).Value;
        if (!string.IsNullOrEmpty(listContent))
            result = listContent.JsonDeserialize<TRes>();
        else
        {
            var objectContent = _objectRegex.Match(llmResponse).Value;
            if (!string.IsNullOrEmpty(objectContent))
                result = objectContent.JsonDeserialize<TRes>();
        }

        return result;
    } 
}