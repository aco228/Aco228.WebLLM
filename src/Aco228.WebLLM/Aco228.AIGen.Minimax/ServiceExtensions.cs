using Aco228.AIGen.Minimax.Services;
using Aco228.AIGen.Models;
using Aco228.AIGen.Services;
using Aco228.Common.Extensions;
using Aco228.Common.Infrastructure;
using Aco228.WService;
using Microsoft.Extensions.DependencyInjection;

namespace Aco228.AIGen.Minimax;

public static class ServiceExtensions
{
    public static void RegisterMinimaxServices(this IServiceCollection services)
        => typeof(ServiceExtensions).RegisterIfNot(() =>
        {
            services.RegisterServicesFromAssembly(typeof(ServiceExtensions).Assembly);
            services.RegisterApiServices(typeof(ServiceExtensions).Assembly);
            services.RegisterPostBuildAction((provider) =>
            {
                var managerInterface = provider.GetService<ITextGenManager>()!;
                var manager = managerInterface as TextGenManager;
                manager.Register<IMinimaxTextGen>(TextGenProvider.OpenRouter, Constants.MinimaxTextModels.Models);
            });
        });
}