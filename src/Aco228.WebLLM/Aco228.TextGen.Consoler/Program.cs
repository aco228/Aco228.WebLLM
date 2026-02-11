// See https://aka.ms/new-console-template for more information

using Aco228.AIGen;
using Aco228.AIGen.ChatGPT;
using Aco228.AIGen.Models;
using Aco228.AIGen.Services;
using Aco228.Common;
using Aco228.TextGen.Claude;
using Aco228.WService;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = await ServiceProviderHelper.CreateProvider(typeof(Program), builder =>
{
    builder.RegisterAIGenServices();
    builder.RegisterChatGptServices();
    builder.RegisterClaudeServices();
    // builder.RegisterGrokServices();
    // builder.RegisterDeepSeekServices();
    builder.RegisterApiServices(typeof(RepoSmallDTO).Assembly);    
});

var textgen = serviceProvider.GetService<ITextGenManager>()!;
var response = await textgen.GetResponse(new()
{
    Type = TextGenProvider.Claude,
    Level = ModelLevel.Low,
    User = "How are you today?",
});

int brk = 0;
Console.WriteLine("Hello, World! + ");