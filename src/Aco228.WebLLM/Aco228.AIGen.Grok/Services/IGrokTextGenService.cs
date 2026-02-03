using System.Text;
using Aco228.AIGen.Grok.Constants;
using Aco228.AIGen.Grok.Models.Req;
using Aco228.AIGen.Grok.Services.Web;
using Aco228.AIGen.Models;
using Aco228.AIGen.Services;

namespace Aco228.AIGen.Grok.Services;

public interface IGrokTextGenService : ITextGen { }

public class GrokTextGenService : TextGenBase, IGrokTextGenService
{
    public override TextGenType Type => TextGenType.Grok;
    private readonly IGrokChatService _service;

    public GrokTextGenService(IGrokChatService service)
    {
        _service = service;
    }
    
    public override void Prepare()
    {
        AddModels(GrokModelList.Models);
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
            .AddMessage(ModelRole.system, system)
            .AddMessage(ModelRole.user, prompt);
        
        return GetResponse(request);
    }

    public override Task<string> Generate(string model, string system, string prompt)
    {
        var request = new MessageRequest()
            .UseModel(model)
            .AddMessage(ModelRole.system, system)
            .AddMessage(ModelRole.user, prompt);
        
        return GetResponse(request);
    }

    private async Task<string> GetResponse(MessageRequest request)
    {
        var apiResponse = await _service.GetResponse(request);

        var sb = new StringBuilder();
        foreach (var choiceDto in apiResponse.choices)
            sb.Append(choiceDto.message?.content);
        
        return sb.ToString();
    }
}