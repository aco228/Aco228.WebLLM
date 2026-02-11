// See https://aka.ms/new-console-template for more information

using Aco228.AIGen;
using Aco228.AIGen.ChatGPT;
using Aco228.AIGen.Gemini;
using Aco228.AIGen.Gemini.Models.Gemini;
using Aco228.AIGen.Gemini.Services.Web.Gemini;
using Aco228.AIGen.Grok;
using Aco228.AIGen.Models;
using Aco228.AIGen.Services;
using Aco228.Common;
using Aco228.GoogleServices;
using Aco228.TextGen.Claude;
using Aco228.WService;
using Aco228.WService.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = await ServiceProviderHelper.CreateProvider(typeof(Program), builder =>
{
    builder.RegisterGoogleServices(new()
    {
       ServiceAccountCredentialsName = "arbo-487008-38359e7d2b41"
    });
    builder.RegisterAIGenServices();
    builder.RegisterChatGptServices();
    builder.RegisterClaudeServices();
    builder.RegisterGrokServices();
    builder.RegisterGeminiServices();
    // builder.RegisterDeepSeekServices();
    builder.RegisterApiServices(typeof(RepoSmallDTO).Assembly);    
});

var textgen = serviceProvider.GetService<ITextGenManager>()!;
var response = await textgen.GetResponse(new()
{
    Type = TextGenProvider.Gemini,
    Level = ModelLevel.Low,
    User = "How are you today?",
});

int brk = 0;
Console.WriteLine("Hello, World! + ");