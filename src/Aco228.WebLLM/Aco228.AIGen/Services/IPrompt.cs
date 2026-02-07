using System.Numerics;
using System.Reflection;
using Aco228.AIGen.Attributes;
using Aco228.AIGen.Helpers;
using Aco228.AIGen.Infrastructure.PromptSerializer.Helpers;
using Aco228.AIGen.Models;
using Aco228.Common.Attributes;
using Aco228.Common.Extensions;
using Aco228.Common.Infrastructure;

namespace Aco228.AIGen.Services;

public interface IPromptBase { }

public interface IPrompt<TReq, TRes> : IPromptBase
{
    Task<TRes?> Execute(TReq request);
}

public abstract class PromptBase<TReq, TRes> : IPrompt<TReq, TRes> where TRes : class
{
    protected virtual ModelLevel? ModelLevel => null;
    protected abstract List<string> SystemPrompt { get; }
    protected virtual ManagedList<TextGenType>? TextGenTypes => null;
    protected virtual ManagedList<ModelDefinition>? ModelDefinition => null;
    protected virtual List<string> AdditionalSystemPrompts { get; } = new();
    protected abstract List<string> UserPrompt { get; }
    protected abstract List<string> Rules { get; }
    protected virtual List<string> AdditionalRules { get; } = new();
    protected virtual List<string> AdditionalGuidelines { get; } = new();
    protected virtual List<PromptSection> Sections { get; } = new();

    [InjectService] public ITextGenManager TextGenManager { get; set; }

    private Tuple<string, string> GetPromptData(TReq request)
    {
        // TODO: Optimize strings with string builder
        
        var inputData = SerializePromptRequestHelper.SerializeToString(request);
        var outputData = new SerializePromptResponseHelper<TRes>().Serialize(
            additionalGuidelines: AdditionalGuidelines);

        var systemPrompt = string.Join(" ", SystemPrompt.GetAddRange(AdditionalSystemPrompts))
            .AppendList("Rules", Rules.GetAddRange(AdditionalRules))
            .AppendSections(Sections)
            .AppendString("Output", outputData);
        
        var userText = string.Join(" ", UserPrompt)
            .AppendString("Input", inputData);

        return new(systemPrompt, userText);
    }
    
    public string GetPromptText(TReq request)
    {
        var (systemPrompt, userText) = GetPromptData(request);
        return string.Join(Environment.NewLine, systemPrompt, userText);
    }
    
    public async Task<TRes?> Execute(TReq request)
    {
        var llmModel = (ModelDefinition ?? TextGenManager.ModelDefinitions)
            .Where(x => x.SupportsJson)
            .Where(x => ModelLevel == null || x.Level == ModelLevel)
            .Where(x => TextGenTypes?.Contains(x.Provider) ?? true)
            .Shuffle().First();
        
        var (systemPrompt, userText) = GetPromptData(request);
        
        var textGenerationRequest = new TextGenerationRequest()
        {
            Type = TextGenTypes?.Take() ?? null,
            Model = llmModel,
            System = systemPrompt,
            Prompt = userText,
            FileUrls = GetFileUrlList(request),
        };
        
        var response = await TextGenManager.Generate(textGenerationRequest);

        if (typeof(TRes) == typeof(string))
            return response as TRes;
        
        var result = PromptHelper.DeserializeResponse<TRes>(response);
        return result;
    }

    private List<string> GetFileUrlList(TReq request)
    {
        var filesList = new List<string>();

        foreach (var propertyInfo in typeof(TReq).GetProperties())
        {
            var imgProp = propertyInfo.GetCustomAttribute<PromptFileIdAttribute>();
            if(imgProp == null)
                continue;
            
            if(propertyInfo.PropertyType != typeof(string))
                throw new Exception("Only string properties are supported for PromptFileIdAttribute");
            var val = propertyInfo.GetValue(request)?.ToString();
            
            if(!string.IsNullOrEmpty(val))
                filesList.Add(val);
        }

        return filesList;
    }
}