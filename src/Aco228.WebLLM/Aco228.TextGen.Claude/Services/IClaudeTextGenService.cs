using System.Text;
using Aco228.AIGen.Models;
using Aco228.AIGen.Services;
using Aco228.TextGen.Claude.Constants;
using Aco228.TextGen.Claude.Models.Web.Request;
using Aco228.TextGen.Claude.Services.Web;

namespace Aco228.TextGen.Claude.Services;

public interface IClaudeTextGenService : ITextGen { }

public class ClaudeTextGenService : TextGenBase, IClaudeTextGenService
{
    public override TextGenType Type => TextGenType.Claude;
    private readonly IClaudeChatApiService _service;

    public ClaudeTextGenService(IClaudeChatApiService service)
    {
        _service = service;
    }
    
    public override void Prepare()
    {
        AddModels(ClaudeModelList.Models);
    }

    public override Task<string> Generate(TextGenerationRequest request)
    {
        throw new NotImplementedException();
    }

    public override Task<string> Generate(string prompt)
    {
        var request = new MessageRequest()
            .UseModel(TakeNextModel())
            .AddMessage(ModelRole.user, prompt);
        
        return GetResponse(request);
    }

    public override Task<string> Generate(string system, string prompt)
    {
        var request = new MessageRequest()
            .UseModel(TakeNextModel())
            .AddMessage(ModelRole.assistant, system)
            .AddMessage(ModelRole.user, prompt);
        
        return GetResponse(request);
    }

    public override Task<string> Generate(string model, string system, string prompt)
    {
        var request = new MessageRequest()
            .UseModel(model)
            .AddMessage(ModelRole.assistant, system)
            .AddMessage(ModelRole.user, prompt);
        
        return GetResponse(request);
    }

    private async Task<string> GetResponse(MessageRequest request)
    {
        var apiResponse = await _service.GetResponse(request);

        var sb = new StringBuilder();
        foreach (var contentDto in apiResponse.content)
            sb.Append(contentDto.text);
        
        return sb.ToString();
    }
}