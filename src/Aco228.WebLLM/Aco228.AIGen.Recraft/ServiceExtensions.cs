using Aco228.AIGen.Models;
using Aco228.AIGen.Recraft.Services;
using Aco228.AIGen.Services;
using Aco228.Common.Extensions;
using Aco228.Common.Infrastructure;
using Aco228.WService;
using Microsoft.Extensions.DependencyInjection;

namespace Aco228.AIGen.Recraft;

public static class ServiceExtensions
{
    public static void RegisterRecraftServices(this IServiceCollection services)
        => typeof(ServiceExtensions).RegisterIfNot(() =>
        {
            services.RegisterApiServices(typeof(ServiceExtensions).Assembly);
            services.RegisterServicesFromAssembly(typeof(ServiceExtensions).Assembly);

            services.RegisterPostBuildAction((provider) =>
            {
                var imageManager = provider.GetService<IImageGenManager>()! as ImageGenManager;
                imageManager.RegisterGenerator<IRecraftImageGen>(ImageGenProvider.Recraft, Constants.RecraftImageModels.Models);
            });
        });
}