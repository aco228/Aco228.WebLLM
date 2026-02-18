using Aco228.AIGen.Ideogram.Services;
using Aco228.AIGen.Models;
using Aco228.AIGen.Services;
using Aco228.Common.Extensions;
using Aco228.Common.Infrastructure;
using Aco228.WService;
using Microsoft.Extensions.DependencyInjection;

namespace Aco228.AIGen.Ideogram;

public static class ServiceExtensions
{
    public static void RegisterIdeogramServices(this IServiceCollection services)
        => typeof(ServiceExtensions).RegisterIfNot(() =>
        {
            services.RegisterServicesFromAssembly(typeof(ServiceExtensions).Assembly);
            services.RegisterApiServices(typeof(ServiceExtensions).Assembly);
            services.RegisterPostBuildAction((pr) =>
            {
                var imageManager = pr.GetService<IImageGenManager>()! as ImageGenManager;
                imageManager.RegisterGenerator<IIdeogramImageGen>(ImageGenProvider.Ideogram, Constants.IdeogramImageModels.Models);
            });
        });
}