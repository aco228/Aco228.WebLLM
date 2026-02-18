// See https://aka.ms/new-console-template for more information

using Aco228.AIGen;
using Aco228.AIGen.BlackForestLabs;
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

await GenerateOpenRouterModelList.Generate();
var service = serviceProvider.GetService<IOpenRouterModelsApiService>()!;
var open = await service.GetModels();

var ids = open.data.Select(x => x.id).ToList();
var idsString = string.Join(Environment.NewLine, ids);

var grokImgApi = serviceProvider.GetService<IGrokImageApiService>()!;
var res = await grokImgApi.GenerateImage(new()
{
    prompt = "A shark is having a rap concert, and is being attacked by a angry puma",
});

int brk = 0;
Console.WriteLine("Hello, World! + ");