using Aco228.Common.Extensions;
using Aco228.Common.Infrastructure;
using Aco228.WService;
using Microsoft.Extensions.DependencyInjection;

namespace Aco228.AIGen.KlingAI;

public static class ServiceExtensions
{
    public static void RegisterKlingAIServices(this IServiceCollection services)
        => typeof(ServiceExtensions).RegisterIfNot(() =>
        {
            services.RegisterApiServices(typeof(ServiceExtensions).Assembly);
            services.RegisterServicesFromAssembly(typeof(ServiceExtensions).Assembly);
        });
}