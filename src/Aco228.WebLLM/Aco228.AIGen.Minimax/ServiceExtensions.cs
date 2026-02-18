using Aco228.Common.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Aco228.AIGen.Minimax;

public static class ServiceExtensions
{
    public static void RegisterMinimaxServices(this IServiceCollection services)
        => typeof(ServiceExtensions).RegisterIfNot(() =>
        {

        });
}