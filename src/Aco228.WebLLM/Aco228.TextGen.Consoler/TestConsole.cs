// See https://aka.ms/new-console-template for more information

using Aco228.AIGen;
using Aco228.AIGen.ChatGPT;
using Aco228.AIGen.Gemini;
using Aco228.AIGen.Gemini.Models.Gemini;
using Aco228.AIGen.Gemini.Services.Web.Gemini;
using Aco228.AIGen.Grok;
using Aco228.AIGen.Models;
using Aco228.AIGen.PoyoAI;
using Aco228.AIGen.PoyoAI.Models;
using Aco228.AIGen.PoyoAI.Services;
using Aco228.AIGen.Services;
using Aco228.Common;
using Aco228.GoogleServices;
using Aco228.TextGen.Claude;
using Aco228.TextGen.Consoler;
using Aco228.WService;
using Aco228.WService.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = await ServiceProviderHelper.CreateProvider(typeof(Program), builder =>
{
    builder.RegisterGoogleServices(new()
    {
       ServiceAccountCredentialsName = "arbo-487008-38359e7d2b41"
    });
    builder.RegisterPoyoAIServices();
    builder.RegisterAIGenServices();
    builder.RegisterChatGptServices();
    builder.RegisterClaudeServices();
    builder.RegisterGrokServices();
    builder.RegisterGeminiServices();
    // builder.RegisterDeepSeekServices();
    builder.RegisterApiServices(typeof(RepoSmallDTO).Assembly);    
});

var tst = ServiceProviderHelper.Construct<Tests>();
await tst.CheckAll("FP9RFJQU9Z5R6Z1B", "LATBXC52PJPTOL1W", "1EV15UQZK2XM9AL9", "LU5ZF9KCCNOVSQK4", "GEGSEZIPVZ7WOG7W");
await tst.GenerateForAll("Shark is having a rap concert, and is being attacked by a angry puma");

var poyo = serviceProvider.GetService<IPoyoImageGen>()!;
var poyoTask = await poyo.GetResponse("GHMJV6PFPM7UKKYQ");

var poyoTaskId = await poyo.GenerateAndGetTaskId(
    PoyoModelType.Flux2Pro,
    "Shark is having a rap concert, and is being attacked by a angry puma",
    ImageSize.Square);

Console.WriteLine($"Flux2Pro: {poyoTaskId}");

var textgen = serviceProvider.GetService<ITextGenManager>()!;
var response = await textgen.GetResponse(new()
{
    Type = TextGenProvider.Gemini,
    Level = ModelLevel.Low,
    User = "How are you today?",
});

int brk = 0;
Console.WriteLine("Hello, World! + ");