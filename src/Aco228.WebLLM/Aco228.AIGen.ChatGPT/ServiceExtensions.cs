using Aco228.AIGen.ChatGPT.Constants;
using Aco228.AIGen.ChatGPT.Services;
using Aco228.AIGen.Models;
using Aco228.AIGen.Services;
using Aco228.Common.Extensions;
using Aco228.WService;
using Microsoft.Extensions.DependencyInjection;

namespace Aco228.AIGen.ChatGPT;

public static class ServiceExtensions
{
    public static void RegisterChatGptServices(this IServiceCollection services)
    {
        services.RegisterApiServices(typeof(ServiceExtensions).Assembly);
        services.RegisterServicesFromAssembly(typeof(ServiceExtensions).Assembly);

        services.RegisterPostBuildAction((serviceProvider) =>
        {
            var manager = serviceProvider.GetService<ITextGenManager>()!;
            manager.Register<IChatGptTextGen>(TextGenType.ChatGPT, ChatGptModelList.Models);
        });
    }
    
}