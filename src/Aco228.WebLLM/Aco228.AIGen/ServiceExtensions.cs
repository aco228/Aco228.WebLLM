using Aco228.Common.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Aco228.AIGen;

public static class ServiceExtensions
{
    public static void RegisterAIGenServices(this IServiceCollection services)
    {
        services.RegisterServicesFromAssembly(typeof(ServiceExtensions).Assembly);
        
    }
}