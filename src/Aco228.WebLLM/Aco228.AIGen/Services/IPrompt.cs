using System.Text;
using Aco228.AIGen.Infrastructure.PromptSerializer;
using Aco228.AIGen.Infrastructure.PromptSerializer.Helpers;
using Aco228.AIGen.Models;
using Aco228.Common.Attributes;
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
    protected virtual ManagedList<TextGenProvider>? TextGenProviders => null;
    protected virtual ManagedList<ModelDefinition>? ModelDefinition => null;
    protected virtual List<PromptSection> Sections { get; } = new();

    protected virtual string UserPrompt { get; } = "";
    protected abstract string PromptName { get; } 

    [InjectService] public ITextGenManager TextGenManager { get; set; }

    private async Task<Tuple<string, string>> GetPromptData(TReq request)
    {
        var outputData = new SerializePromptResponseHelper<TRes>().Serialize();
        var systemPrompt = await PromptTextsProvider.GetPromptText(PromptName);
        systemPrompt.AppendSections(Sections)
            .AppendString("Output", outputData.ToString());

        var userPrompt = new StringBuilder(UserPrompt)
            .Append(Environment.NewLine)
            .Append(SerializePromptRequestHelper.SerializeToString(request));
    
        return new(systemPrompt.ToString(), userPrompt.ToString());
    }
    
    public async Task<string> GetPromptText(TReq request)
    {
        var (systemPrompt, userText) = await GetPromptData(request);
        return string.Join(Environment.NewLine, systemPrompt, userText);
    }
    
    public async Task<TRes?> Execute(TReq request)
    {
        return null;
        // var llmModel = (ModelDefinition ?? TextGenManager.ModelDefinitions)
        //     .Where(x => x.SupportsJson)
        //     .Where(x => ModelLevel == null || x.Level == ModelLevel)
        //     .Where(x => TextGenProviders?.Contains(x.Provider) ?? true)
        //     .Shuffle().First();
        //
        // var (systemPrompt, userText) = GetPromptData(request);
        //
        // var textGenerationRequest = new TextGenerationRequest()
        // {
        //     Type = TextGenProviders?.Take() ?? null,
        //     Model = llmModel,
        //     System = systemPrompt,
        //     Prompt = userText,
        //     FileUrls = GetFileUrlList(request),
        // };
        //
        // var response = await TextGenManager.Generate(textGenerationRequest);
        //
        // if (typeof(TRes) == typeof(string))
        //     return response as TRes;
        //
        // var result = PromptHelper.DeserializeResponse<TRes>(response);
        // return result;
    }
    //
    // private List<string> GetFileUrlList(TReq request)
    // {
    //     var filesList = new List<string>();
    //
    //     foreach (var propertyInfo in typeof(TReq).GetProperties())
    //     {
    //         var imgProp = propertyInfo.GetCustomAttribute<PromptFileIdAttribute>();
    //         if(imgProp == null)
    //             continue;
    //         
    //         if(propertyInfo.PropertyType != typeof(string))
    //             throw new Exception("Only string properties are supported for PromptFileIdAttribute");
    //         var val = propertyInfo.GetValue(request)?.ToString();
    //         
    //         if(!string.IsNullOrEmpty(val))
    //             filesList.Add(val);
    //     }
    //
    //     return filesList;
    // }
}