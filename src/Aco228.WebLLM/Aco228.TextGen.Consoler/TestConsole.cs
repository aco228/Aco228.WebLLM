// See https://aka.ms/new-console-template for more information

using Aco228.AIGen;
using Aco228.AIGen.BlackForestLabs;
using Aco228.AIGen.BlackForestLabs.Services.Web;
using Aco228.AIGen.ChatGPT;
using Aco228.AIGen.Gemini;
using Aco228.AIGen.Gemini.Models.Gemini;
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
        ProjectId = "arbo-487008-38359e7d2b41",
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
    // builder.RegisterDeepSeekServices();
    builder.RegisterApiServices(typeof(RepoSmallDTO).Assembly);    
});


var imageService = serviceProvider.GetService<IImageGenManager>()!;
var resa = await imageService.GetResultFor(ImageGenProvider.BlackForestLabs, "541d045f-b358-4397-90ce-7af202ee98a2"); 

var imgres = await imageService.Generate(new()
{
    ImageSize = ImageSize.Square,
    Prompt = "Wild puma is angry and is attacking a shark that is currently having a hiphop concert",
    Provider = ImageGenProvider.BlackForestLabs,
    Count = 1,
});

var service = serviceProvider.GetService<ITextGenManager>()!;
var res = await service.GetResponse(new()
{
    PriceLevel = PriceLevel.Low,
    Provider = TextGenProvider.Minimax,
    User = "How are you?"
});

int brk = 0;
Console.WriteLine("Hello, World! + ");