// See https://aka.ms/new-console-template for more information

using Aco228.AIGen;
using Aco228.AIGen.AtlasCloud;
using Aco228.AIGen.AtlasCloud.Services.Web;
using Aco228.AIGen.BlackForestLabs;
using Aco228.AIGen.BlackForestLabs.Services.Web;
using Aco228.AIGen.ChatGPT;
using Aco228.AIGen.DeepAI;
using Aco228.AIGen.DeepAI.Models.Web.CreateImage;
using Aco228.AIGen.DeepAI.Services.Web;
using Aco228.AIGen.FalAi;
using Aco228.AIGen.FalAi.Core;
using Aco228.AIGen.FalAi.Models;
using Aco228.AIGen.FalAi.Services.Api;
using Aco228.AIGen.Gemini;
using Aco228.AIGen.Gemini.Models.Gemini;
using Aco228.AIGen.Gemini.Models.GoogleAiStudio.Images;
using Aco228.AIGen.Gemini.Services.Web;
using Aco228.AIGen.Gemini.Services.Web.Gemini;
using Aco228.AIGen.Grok;
using Aco228.AIGen.Grok.Services.Web;
using Aco228.AIGen.Ideogram;
using Aco228.AIGen.Minimax;
using Aco228.AIGen.Models;
using Aco228.AIGen.OpenRouter;
using Aco228.AIGen.OpenRouter.Infrastructure;
using Aco228.AIGen.OpenRouter.Services.Web;
using Aco228.AIGen.PoyoAI;
using Aco228.AIGen.PoyoAI.Models;
using Aco228.AIGen.PoyoAI.Services;
using Aco228.AIGen.Recraft;
using Aco228.AIGen.Services;
using Aco228.Common;
using Aco228.GoogleServices;
using Aco228.TextGen.Claude;
using Aco228.TextGen.Consoler;
using Aco228.WService;
using Aco228.WService.Infrastructure;
using Google.Apis.Util;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = await ServiceProviderHelper.CreateProvider(typeof(Program), builder =>
{
    builder.RegisterGoogleServices(new()
    {
        ProjectId = Environment.GetEnvironmentVariable("GOOGLE_PROJECT_ID") ?? throw new InvalidOperationException("GoogleProjectId is not set"),
        ServiceAccountCredentialsPath = @"C:\Users\Lenovo\Documents\CKArbo\app\google\credentials.json",
    });
    builder.RegisterPoyoAIServices();
    builder.RegisterAIGenServices();
    builder.RegisterChatGptServices();
    builder.RegisterClaudeServices();
    builder.RegisterGrokServices();
    builder.RegisterGeminiServices();
    builder.RegisterMinimaxServices();
    builder.RegisterBlackForestLabsServices();
    builder.RegisterRecraftServices();
    builder.RegisterIdeogramServices();
    builder.RegisterOpenRouterServices();
    builder.RegisterAtlasCloudServices();
    builder.RegisterDeepAiServices();
    builder.RegisterFalAiServices();
    // builder.RegisterDeepSeekServices();
    builder.RegisterApiServices(typeof(RepoSmallDTO).Assembly);    
});

var cls = JsonToClassConverter.ConvertJsonToClass("FalAiImageResponse",
    @"{""images"":[{""url"":""https://v3b.fal.media/files/b/0a90ef88/qywCveqM57BdZOXNQc4H7_0bc1c690279f4117829119c75fea35b2.png"",""content_type"":""image/png"",""file_name"":""0bc1c690279f4117829119c75fea35b2.png"",""file_size"":3539356,""width"":null,""height"":null}],""seed"":1547064457}");

var falService = serviceProvider.GetService<IFalAiTextToImageApiService>()!;
var falRes = await falService.RequestImage("bytedance/seedream/v5/lite/text-to-image", new()
{
    prompt = "A cute puppy playing in the grass",
    image_size = FalImageSize.square.ToString(),
    num_images = 1,
});


var imageService = serviceProvider.GetService<IImageGenManager>()!;
var imgres = await imageService.Generate(new()
{
    ImageSize = ImageSize.Square,
    Prompt = "Wild puma is angry and is attacking a shark that is currently having a hiphop concert",
    Provider = ImageGenProvider.GoogleAiStudio,
    Count = 1,
});


var service = serviceProvider.GetService<ITextGenManager>()!;
var res = await service.GetResponse(new()
{
    PriceLevel = PriceLevel.Low,
    Provider = TextGenProvider.NanoBanana,
    User = "How are you?"
});

int brk = 0;

var atlas = serviceProvider.GetService<IAtlasCloudImageApiService>()!;
var rea  = await atlas.GetResult("b000f4d6b9104f199e220b1c3909eed9");




Console.WriteLine("Hello, World! + ");