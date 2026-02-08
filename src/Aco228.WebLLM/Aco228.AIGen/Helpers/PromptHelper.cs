using System.Text.Json;
using System.Text.RegularExpressions;
using Aco228.AIGen.Services;
using Aco228.Common;
using Aco228.Common.Extensions;
using Aco228.Common.Models;

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
        
        var typeDefinition = TypeDeconstructor.Get(typeof(TRes));
        
        TRes? result = default;
        string? jsonContent = null;

        if (typeDefinition.IsList)
            jsonContent = _listRegex.Match(llmResponse).Value;
        else if (typeDefinition.IsClass)
            jsonContent = _objectRegex.Match(llmResponse).Value;
        
        if(string.IsNullOrEmpty(jsonContent)) 
            throw new Exception("Unable to deserialize response");
        
        result = jsonContent.JsonDeserialize<TRes>();
        return result;
    } 
}