using Aco228.AIGen.Models;
using Aco228.AIGen.PoyoAI.Constants;
using Aco228.AIGen.PoyoAI.Services;
using Aco228.AIGen.Services;
using Aco228.Common.Extensions;
using Aco228.WService;
using Microsoft.Extensions.DependencyInjection;

namespace Aco228.AIGen.PoyoAI;

public static class ServiceExtensions
{
    public static void RegisterPoyoAIServices(this IServiceCollection services)
    {
        services.RegisterApiServices(typeof(ServiceExtensions).Assembly);
        services.AddTransient<IPoyoImageGen, PoyoImageGen>();

        services.RegisterPostBuildAction((pr) =>
        {
            var imageManager = pr.GetService<IImgGenManager>()! as ImgGenManager;
            imageManager.RegisterGenerator<IPoyoImageGen>(ImageGenProvider.Poyo, PoyoImages.Models);
        });
    }
}