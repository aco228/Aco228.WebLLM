using Aco228.AIGen.Gemini.Services;
using Aco228.AIGen.Models;
using Aco228.AIGen.Services;
using Aco228.Common.Extensions;
using Aco228.Common.Infrastructure;
using Aco228.WService;
using Microsoft.Extensions.DependencyInjection;

namespace Aco228.AIGen.Gemini;

public static class ServiceExtensions
{
    public static void RegisterGeminiServices(this IServiceCollection services)
        => typeof(ServiceExtensions).RegisterIfNot(() =>
        {
            services.RegisterServicesFromAssembly(typeof(ServiceExtensions).Assembly);
            services.RegisterApiServices(typeof(ServiceExtensions).Assembly);

            services.RegisterPostBuildAction((pr) =>
            {
                var manager = pr.GetService<ITextGenManager>()! as TextGenManager;
                manager.Register<IGeminiTextGen>(TextGenProvider.Gemini, Constants.GeminiModelList.Models);
                manager.Register<IGoogleAiStudioTextGen>(TextGenProvider.GoogleAiStudio, Constants.GoogleAiStudioModelList.Models);
                
                var imageManager = pr.GetService<IImageGenManager>()! as ImageGenManager;
                imageManager.RegisterGenerator<IGoogleAiStudioImageGen>(ImageGenProvider.GoogleAiStudio, Constants.GoogleAiStudioImageModelList.Models);
            });
        });
}