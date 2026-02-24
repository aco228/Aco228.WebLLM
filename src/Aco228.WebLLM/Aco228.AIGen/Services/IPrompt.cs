using System.Reflection;
using System.Text;
using Aco228.AIGen.Attributes;
using Aco228.AIGen.Helpers;
using Aco228.AIGen.Infrastructure.PromptSerializer;
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
    protected virtual PriceLevel PriceLevel => Models.PriceLevel.Low;
    protected virtual ManagedList<TextGenProvider>? TextGenProviders => null;
    protected virtual ManagedList<ModelDefinition>? ModelDefinition => null;
    protected virtual List<PromptSection> Sections { get; } = new();
    protected virtual bool UsePremiumModels => false;
    
    [InjectService] public ITextGenManager TextGenManager { get; set; }

    protected virtual string UserPrompt { get; } = "";
    protected abstract string PromptName { get; }

    public TextGenProvider LastProviderUsed { get; private set; } = TextGenProvider.Unknown;

    private async Task<Tuple<string, string>> GetPromptData(TReq request)
    {
        var outputData = new SerializePromptResponseHelper<TRes>().Serialize();
        var systemPrompt = await PromptTextsProvider.GetPromptText(PromptName);
        systemPrompt.AppendSections(Sections)
            .AppendString("Output", outputData.ToString());

        var userPrompt = new StringBuilder(UserPrompt)
            .Append(Environment.NewLine)
            .Append(SerializePromptRequestHelper.SerializeToString(request));
        
        return new(await ModifySystemPrompt(systemPrompt.ToString(), request), userPrompt.ToString());
    }
    
    protected virtual Task<string> ModifySystemPrompt(string systemPrompt, TReq request) => Task.FromResult(systemPrompt);
    
    public async Task<string> GetPromptText(TReq request)
    {
        var (systemPrompt, userText) = await GetPromptData(request);
        return string.Join(Environment.NewLine, systemPrompt, userText);
    }
    
    public async Task<TRes?> Execute(TReq request)
    {
        var llmModels = ModelDefinition ?? TextGenManager.ModelDefinitions
            .Where(x => !UsePremiumModels && x.PriceLevel != PriceLevel.High)
            .Where(x => PriceLevel == null || x?.PriceLevel == PriceLevel)
            .Where(x => TextGenProviders?.Contains(x.Provider) ?? true)
            .ToManagedList();
        
        if(!llmModels.Any())
            throw new Exception("No suitable LLM model found");

        for (int i = 0; i < 6; i++)
        {
            var llmModel = llmModels.Shuffle().First();
            var (systemPrompt, userText) = await GetPromptData(request);
            Console.WriteLine($"Using LLM models: {llmModel.Provider}.{llmModel.ModelApiName}");

            var textGenerationRequest = new TextGenerationRequest()
            {
                Model = llmModel,
                User = userText,
                System = systemPrompt,
                ImageUrls = GetImageUrls(request),
            };
            
            TextGenResponse? textGenResponse = null;
            
            try
            {
                textGenResponse = await TextGenManager.GetResponse(textGenerationRequest);
                LastProviderUsed = llmModel.Provider;
                return PromptHelper.DeserializeResponse<TRes>(textGenResponse.Response);
            }
            catch(Exception ex)
            {
                await Task.Delay(100); // TODO: make better reporting for LLM's not doing their job
            }
        }
        throw new Exception("Failed to generate response");
    }
    
    private List<string> GetImageUrls(TReq request)
    {
        var filesList = new List<string>();
    
        foreach (var propertyInfo in typeof(TReq).GetProperties())
        {
            var imgProp = propertyInfo.GetCustomAttribute<PromptImageUrlAttribute>();
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