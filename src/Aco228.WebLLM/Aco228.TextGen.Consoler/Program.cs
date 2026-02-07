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
using Aco228.AIGen.Grok;
using Aco228.AIGen.Grok.Services;
using Aco228.AIGen.Grok.Services.Web;
using Aco228.AIGen.Helpers;
using Aco228.Common;
using Aco228.Common.Helpers;
using Aco228.WService;
using Aco228.WService.Infrastructure;
using DotNetEnv;
using Microsoft.Extensions.DependencyInjection;


var serviceProvider = await ServiceProviderHelper.Construct(typeof(Program), builder =>
{
    builder.RegisterAIGenServices();
    builder.RegisterChatGptServices();
    builder.RegisterClaudeServices();
    builder.RegisterGrokServices();
    builder.RegisterDeepSeekServices();
    builder.RegisterApiServices(typeof(RepoSmallDTO).Assembly);    
});

var adthemeGenerator = PromptHelper.Get<AdThemeGeneratorPrompt>();
var prompt = await adthemeGenerator.GetPromptText(new PromptAdThemeGeneratorRequest()
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


int brk = 0;
Console.WriteLine("Hello, World! + ");