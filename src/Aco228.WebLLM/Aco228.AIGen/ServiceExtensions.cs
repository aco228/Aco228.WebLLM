using Aco228.Common.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Aco228.AIGen;

public static class ServiceExtensions
{
    private static bool _registered = false;
    
    public static void RegisterAIGenServices(this IServiceCollection services)
    {
        if(_registered) return;
        services.RegisterServicesFromAssembly(typeof(ServiceExtensions).Assembly);
        _registered = true;
        
    }
}