using Aco228.AIGen.Helpers;
using Aco228.AIGen.Infrastructure.PromptSerializer.Helpers;
using Aco228.AIGen.Models;
using Aco228.Common.Attributes;

namespace Aco228.AIGen.Services;

public interface IPrompt<TReq, TRes>
{
    Task<TRes?> Execute(TReq request);
}

public abstract class PromptBase<TReq, TRes> : IPrompt<TReq, TRes>
{
    protected abstract string SystemPrompt { get; } 
    protected abstract string UserPrompt { get; } 
    protected abstract List<string> Rules { get; }
    protected virtual ModelLevel? ModelLevel => null;
    protected virtual TextGenType? GenType => null;
     
    [InjectService] public ITextGenManager TextGenManager { get; set; }
    
    public async Task<TRes?> Execute(TReq request)
    {
        var inputData = SerializePromptRequestHelper.SerializeToString(request);
        var outputData = new SerializePromptResponseHelper<TRes>().Serialize();

        var systemPrompt = (SystemPrompt.Replace("\r\n", " ").Replace("\n", " ").Trim() + Environment.NewLine)
            .AppendList("Rules", Rules)
            .AppendString("Output", outputData);

        var userText = (UserPrompt.Replace("\r\n", " ").Replace("\n", " ").Trim() + Environment.NewLine)
                .AppendString("Input", inputData);

        var llmModel = TextGenManager.ModelDefinitions
            .Where(x => x.SupportsJson)
            .Where(x => ModelLevel == null || x.Level == ModelLevel)
            .Where(x => GenType == null || x.Provider == GenType)
            .Shuffle().First();
        
        var response = await TextGenManager.Generate(llmModel, systemPrompt, userText);
        var result = PromptHelpers.DeserializeResponse<TRes>(response);

        return result;
    }
}