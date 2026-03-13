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
using Aco228.AIGen.KlingAI;
using Aco228.AIGen.KlingAI.Services.Api;
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
using Aco228.AIGen.LeonardoAI;
using Aco228.AIGen.LeonardoAI.Core;
using Aco228.AIGen.LeonardoAI.Services;
using Aco228.AIGen.LeonardoAI.Services.Api;
using Aco228.TextGen.Claude;
using Aco228.TextGen.Consoler;
using Aco228.TextGen.Perplexity;
using Aco228.TextGen.Perplexity.Services.Api;
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
    builder.RegisterKlingAIServices();
    builder.RegisterLeonardoAIServices();
    builder.RegisterPerplexityServices();
    // builder.RegisterDeepSeekServices();
    builder.RegisterApiServices(typeof(RepoSmallDTO).Assembly);    
});

var prawRes = JsonToClassConverter.ConvertJsonToClass("SonarResponse", @"{""id"":""5edcdc05-932c-40f4-a5b9-a55ed73fc821"",""model"":""sonar-pro"",""created"":1773434171,""usage"":{""prompt_tokens"":8,""completion_tokens"":65,""total_tokens"":73,""search_context_size"":""low"",""cost"":{""input_tokens_cost"":0.00002,""output_tokens_cost"":0.00098,""request_cost"":0.006,""total_cost"":0.007}},""citations"":[""https://www.britannica.com/place/Paris"",""https://www.britannica.com/place/France"",""https://en.wikipedia.org/wiki/Paris"",""https://en.wikipedia.org/wiki/List_of_capitals_of_France"",""http://www.paris-city.fr/GB/paris-city/au-fil-du-temps/histoire.php"",""https://www.youtube.com/watch?v=_6UBxbX4GiQ"",""https://mapy.com/en/?id=88878"",""https://www.youtube.com/shorts/faP_tmetYj8""],""search_results"":[{""title"":""Paris | Definition, Map, Population, Facts, & History - Britannica"",""url"":""https://www.britannica.com/place/Paris"",""date"":""2026-03-13"",""last_updated"":""2026-03-13"",""snippet"":""Paris, city and capital of France, located along the Seine River, in the north-central part of the country. Paris is one of the world's most important and ..."",""source"":""web""},{""title"":""France | History, Maps, Flag, Population, Cities, Capital, & Facts"",""url"":""https://www.britannica.com/place/France"",""date"":""2026-03-10"",""last_updated"":""2026-03-13"",""snippet"":""The capital and by far the most important city of France is Paris, one of the world's preeminent cultural and commercial centres."",""source"":""web""},{""title"":""Paris - Wikipedia"",""url"":""https://en.wikipedia.org/wiki/Paris"",""date"":""2001-11-06"",""last_updated"":""2026-03-10"",""snippet"":""Paris is the capital and largest city of France, with an estimated city population of 2.04 million in an area of 105.4 km2 (40.7 sq mi), and a metropolitan ..."",""source"":""web""},{""title"":""List of capitals of France - Wikipedia"",""url"":""https://en.wikipedia.org/wiki/List_of_capitals_of_France"",""date"":""2003-01-15"",""last_updated"":""2026-03-10"",""snippet"":""This is a chronological list of capitals of France. The capital of France has been Paris since its liberation in 1944."",""source"":""web""},{""title"":""The birth of the french capital - History of Paris city"",""url"":""http://www.paris-city.fr/GB/paris-city/au-fil-du-temps/histoire.php"",""last_updated"":""2026-03-06"",""snippet"":""The middle ages is a period of European history that spans from 500-1500 AD. During this millennium, Paris became the capital of France."",""source"":""web""},{""title"":""Paris Capital Of France In 4K | - YouTube"",""url"":""https://www.youtube.com/watch?v=_6UBxbX4GiQ"",""date"":""2024-12-07"",""last_updated"":""2026-03-13"",""snippet"":""Paris Capital City Of France In 4K Ultra HD Video | Paris, France Capital And Largest City | Paris Is A Major European City And A Global ..."",""source"":""web""},{""title"":""Paris (Capital) - Mapy.com"",""url"":""https://mapy.com/en/?id=88878"",""snippet"":""Paris, the capital of France, is a world-renowned city for its history, art, and architecture. Located in the heart of the Paris Basin, on the banks of the ..."",""source"":""web""},{""title"":""What's the Capital of France? Find Out with Fun Facts ... - YouTube"",""url"":""https://www.youtube.com/shorts/faP_tmetYj8"",""date"":""2025-01-10"",""last_updated"":""2025-05-24"",""snippet"":""Do you know what city is called the 'City of Light'? Join us for this exciting quiz where we uncover the capital of France!"",""source"":""web""}],""object"":""chat.completion"",""choices"":[{""index"":0,""message"":{""role"":""assistant"",""content"":""**Paris** is the capital of France[1]. Located along the Seine River in the north-central part of the country, Paris is one of the world's most important cultural and commercial centres[2]. The city has served as France's capital since 1945, following its liberation in 1944[4].""},""delta"":{""role"":""assistant"",""content"":""""},""finish_reason"":""stop""}]}");

var perplexity = serviceProvider.GetService<IPerplexitySonarApiService>()!;
var praw = await perplexity.GetResponseRaw(new()
{
    messages = new()
    {
        new()
        {
            role = "user",
            content = "What is the capital of France?",
        }
    }
});

var leonardoApi = serviceProvider.GetService<ILeonardoGenerationApiService>()!;
var gen = await leonardoApi.GetGenerationStatus("23fc2577-e0d5-4b63-a95d-7a85ff0afd86");


var leonardoAI = serviceProvider.GetService<ILeonardoAIImageGen>()!;
var lres = await leonardoAI.Generate(new()
{
    ImageSize = ImageSize.Square,
    Prompt = "Wild puma is angry and is attacking a shark that is currently having a hiphop concert",
    Count = 1,
});

var falService = serviceProvider.GetService<IKlingAiVideoGenerationApiService>()!;
var vid = await falService.GetStatus("9c0d2066-9c23-44a3-b6b3-06242a8a2e7f");

var reskling = await falService.Generate(new()
{
    prompt = "A cute little rabbit wearing glasses, sitting at a table, reading a newspaper, with a cup of cappuccino on the table",
    duration = 5,
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