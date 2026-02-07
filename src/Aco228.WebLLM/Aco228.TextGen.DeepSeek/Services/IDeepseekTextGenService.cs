using System.Text;
using Aco228.AIGen.Models;
using Aco228.AIGen.Services;
using Aco228.TextGen.DeepSeek.Constants;
using Aco228.TextGen.DeepSeek.Models.Req;
using Aco228.TextGen.DeepSeek.Services.Web;

namespace Aco228.TextGen.DeepSeek.Services;

public interface IDeepseekTextGenService : ITextGen { }

public class DeepseekTextGenService : TextGenBase, IDeepseekTextGenService
{
    private readonly IDeepseekChatService _service;
    public override TextGenType Type => TextGenType.DeepSeek;

    public DeepseekTextGenService(IDeepseekChatService service)
    {
        _service = service;
    }
    
    public override void Prepare()
    {
        AddModels(DeepSeekModelList.Models);
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
        foreach (var contentDto in apiResponse.choices)
            sb.Append(contentDto.message.content);
        
        return sb.ToString();
    }
}