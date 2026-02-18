using Aco228.AIGen.Models;
using Aco228.AIGen.OpenRouter.Services;
using Aco228.AIGen.Services;
using Aco228.Common.Extensions;
using Aco228.Common.Infrastructure;
using Aco228.WService;
using Microsoft.Extensions.DependencyInjection;

namespace Aco228.AIGen.OpenRouter;

public static class ServiceExtensions
{
    public static void RegisterOpenRouterServices(this IServiceCollection services)
        => typeof(ServiceExtensions).RegisterIfNot(() =>
        {
            services.RegisterApiServices(typeof(ServiceExtensions).Assembly);
            services.RegisterServicesFromAssembly(typeof(ServiceExtensions).Assembly);
            
            
            services.RegisterPostBuildAction((serviceProvider) =>
            {
                var managerInterface = serviceProvider.GetService<ITextGenManager>()!;
                var manager = managerInterface as TextGenManager;
                manager.Register<IOpenRouteTextGen>(TextGenProvider.OpenRouter, Constants.OpenRouterModelList.Models);
            });
        });
}