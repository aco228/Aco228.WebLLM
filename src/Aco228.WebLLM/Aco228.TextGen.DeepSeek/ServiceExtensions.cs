using Aco228.AIGen.Models;
using Aco228.AIGen.Services;
using Aco228.Common.Extensions;
using Aco228.TextGen.DeepSeek.Constants;
using Aco228.TextGen.DeepSeek.Services;
using Aco228.WService;
using Microsoft.Extensions.DependencyInjection;

namespace Aco228.TextGen.DeepSeek;

public static class ServiceExtensions
{
    public static void RegisterDeepSeekServices(this IServiceCollection services)
    {
        services.RegisterServicesFromAssembly(typeof(ServiceExtensions).Assembly);
        services.RegisterApiServices(typeof(ServiceExtensions).Assembly);

        services.RegisterPostBuildAction((pr) =>
        {
            var manager = pr.GetService<ITextGenManager>()!;
            manager.Register<IDeepseekTextGenService>(TextGenType.DeepSeek, DeepSeekModelList.Models);
        });
    }
}