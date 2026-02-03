// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using Aco228.AIGen;
using Aco228.AIGen.ChatGPT;
using Aco228.AIGen.ChatGPT.Core;
using Aco228.AIGen.ChatGPT.Services;
using Aco228.AIGen.ChatGPT.Services.Web;
using Aco228.AIGen.Models;
using Aco228.AIGen.Services;
using Aco228.Common.Extensions;
using Aco228.Common.Infrastructure.Yaml;
using Aco228.Common.LocalStorage;
using Aco228.TextGen.Claude;
using Aco228.TextGen.Claude.Services;
using Aco228.TextGen.Consoler.Promts;
using Aco228.TextGen.Consoler.WServiceTests;
using Aco228.TextGen.DeepSeek;
using Aco228.TextGen.DeepSeek.Services;
using Aco228.TextGen.DeepSeek.Services.Web;
using Aco228.TextGen.Grok;
using Aco228.TextGen.Grok.Services;
using Aco228.TextGen.Grok.Services.Web;
using Aco228.WService;
using Aco228.WService.Infrastructure;
using DotNetEnv;
using Microsoft.Extensions.DependencyInjection;

Env.Load();

var builder = new ServiceCollection();
builder.RegisterServicesFromAssembly(typeof(Program).Assembly);
builder.RegisterAIGenServices();
builder.RegisterChatGptServices();
builder.RegisterClaudeServices();
builder.RegisterGrokServices();
builder.RegisterDeepSeekServices();
builder.RegisterApiServices(typeof(RepoSmallDTO).Assembly);
var serviceProvider = builder.BuildCollection();

var adthemeGenerator = serviceProvider.GetService<IAdThemeGeneratorPrompt>()!;
var res = await adthemeGenerator.Execute(new PromptAdThemeGeneratorRequest()
{
    Category = "Health",
    Vertical = "Weight Loss",
    NumberOfThemes = 1,
    Inspiration = new()
    {
        "Weight loss plans for menopause",
        "Low impact weight loss for bad knees",
        "Weight loss for frequent business travelers",
        "Sustainable weight loss after failing Keto",
        "Semaglutide vs bariatric surgery comparison"
    }
});


var chatWebService = serviceProvider.GetService<IChatGptTextGen>()!;
// var gptRes = await chatWebService.GetResponse("How are you today?");

// var dto = JsonToClassConverter.ConvertJsonToClass(gptRes, "GptTextResponseDTO");

int a = 0;

// var service = WServiceHelper.GetWebService<IDummyApiService>();
// var service = WServiceHelper.GetWebService<IGithubWebService>();
// var response = await service.GetRepos("aco228");

// var classResponse = new WCreateClassModelService().ConvertJsonToClass(response, "RepoDTO");
// Console.WriteLine(classResponse);

// var response = await File.ReadAllTextAsync("C:\\Users\\Lenovo\\Desktop\\temp\\github.json");
// var data = JsonSerializer.Deserialize<List<RepoSmallDTO>>(response, WJsonSettings.DefaultOptions);

var service1 = serviceProvider.GetService<IDummyApiService>();
var service2 = serviceProvider.GetService<IDummyApiService>();
var service = serviceProvider.GetService<IDummyApiService>();
var response = await service.PatchPost(1, new()
{
    DasIstTitle = "Koji je kurac u pitanju",
});

Console.WriteLine("Hello, World! + " + response);