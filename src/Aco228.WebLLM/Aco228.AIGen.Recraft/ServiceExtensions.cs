using Aco228.Common.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Aco228.AIGen.Recraft;

public static class ServiceExtensions
{
    public static void RegisterRecraftServices(this IServiceCollection services)
        => typeof(ServiceExtensions).RegisterIfNot(() =>
        {

        });
}