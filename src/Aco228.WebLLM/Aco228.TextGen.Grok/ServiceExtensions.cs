using Aco228.AIGen.Models;
using Aco228.AIGen.Services;
using Aco228.Common.Extensions;
using Aco228.TextGen.Grok.Constants;
using Aco228.TextGen.Grok.Services;
using Aco228.WService;
using Microsoft.Extensions.DependencyInjection;

namespace Aco228.TextGen.Grok;

public static class ServiceExtensions
{
    public static void RegisterGrokServices(this IServiceCollection services)
    {
        services.RegisterServicesFromAssembly(typeof(ServiceExtensions).Assembly);
        services.RegisterApiServices(typeof(ServiceExtensions).Assembly);

        services.RegisterPostBuildAction((pr) =>
        {
            var manager = pr.GetService<ITextGenManager>()!;
            manager.Register<IGrokTextGenService>(TextGenType.Grok, GrokModelList.Models);
        });
    }
}