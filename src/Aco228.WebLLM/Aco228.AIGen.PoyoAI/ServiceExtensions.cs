using Aco228.AIGen.PoyoAI.Services;
using Aco228.WService;
using Microsoft.Extensions.DependencyInjection;

namespace Aco228.AIGen.PoyoAI;

public static class ServiceExtensions
{
    public static void RegisterPoyoAIServices(this IServiceCollection services)
    {
        services.RegisterApiServices(typeof(ServiceExtensions).Assembly);
        services.AddTransient<IPoyoImageGen, PoyoImageGen>();
    }
}