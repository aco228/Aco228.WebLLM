using Aco228.Common.Extensions;
using Aco228.Common.Infrastructure;
using Aco228.WService;
using Microsoft.Extensions.DependencyInjection;

namespace Aco228.TextGen.Perplexity;

public static class ServiceExtensions
{
    public static void RegisterPerplexityServices(this IServiceCollection services)
        => typeof(ServiceExtensions).RegisterIfNot(() =>
        {
            services.RegisterServicesFromAssembly(typeof(ServiceExtensions).Assembly);
            services.RegisterApiServices(typeof(ServiceExtensions).Assembly);
        });
}