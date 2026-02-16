using Aco228.Common.Extensions;
using Aco228.Common.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Aco228.AIGen;

public static class ServiceExtensions
{
    public static void RegisterAIGenServices(this IServiceCollection services)
        => typeof(ServiceExtensions).RegisterIfNot(() =>
        {
            services.RegisterServicesFromAssembly(typeof(ServiceExtensions).Assembly);
        });
}