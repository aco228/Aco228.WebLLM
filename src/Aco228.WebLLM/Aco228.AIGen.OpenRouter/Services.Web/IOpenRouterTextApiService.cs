using Aco228.AIGen.OpenRouter.Core;

namespace Aco228.AIGen.OpenRouter.Services.Web;

/// <summary>
/// 
/// </summary>
public interface IOpenRouterTextApiService : IOpenRouterServiceBase
{
    Task<string> GenerateText(string prompt);
    
}