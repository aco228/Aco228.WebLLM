using Aco228.AIGen.Models;
using Aco228.AIGen.Services;
using Aco228.Common.Extensions;
using Aco228.Common.Infrastructure;
using Aco228.TextGen.Claude.Constants;
using Aco228.TextGen.Claude.Services;
using Aco228.WService;
using Microsoft.Extensions.DependencyInjection;

namespace Aco228.TextGen.Claude;

public static class ServiceExtensions
{
    public static void RegisterClaudeServices(this IServiceCollection services)
        => typeof(ServiceExtensions).RegisterIfNot(() =>
        {
            services.RegisterServicesFromAssembly(typeof(ServiceExtensions).Assembly);
            services.RegisterApiServices(typeof(ServiceExtensions).Assembly);

            services.RegisterPostBuildAction((pr) =>
            {
                var manager = pr.GetService<ITextGenManager>()! as TextGenManager;
                manager.Register<IClaudeTextGenService>(TextGenProvider.Claude, ClaudeModelList.Models);
            });
        });
}