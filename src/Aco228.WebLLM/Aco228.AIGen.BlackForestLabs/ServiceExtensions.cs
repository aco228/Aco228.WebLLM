using Aco228.Common.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Aco228.AIGen.BlackForestLabs;

public static class ServiceExtensions
{
    public static void RegisterBlackForestLabsServices(this IServiceCollection services)
        => typeof(ServiceExtensions).RegisterIfNot(() =>
        {

        });
}