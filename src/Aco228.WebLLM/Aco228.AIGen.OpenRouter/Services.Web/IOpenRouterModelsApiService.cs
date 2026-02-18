using Aco228.AIGen.OpenRouter.Core;
using Aco228.AIGen.OpenRouter.Models.Web;
using Aco228.AIGen.OpenRouter.Models.Web.Models;
using Aco228.WService.Models.Attributes.MethodAttributes;
using Aco228.WService.Models.Attributes.ParameterAttributes;

namespace Aco228.AIGen.OpenRouter.Services.Web;

public interface IOpenRouterModelsApiService : IOpenRouterServiceBase
{
    [ApiGet("models")]
    Task<string> GetModelsString([ApiToQuery] OpenRouterCategoryType? categoryType = null);
    
    [ApiGet("models")]
    Task<OpenRouterModelDto> GetModels([ApiToQuery] OpenRouterCategoryType? categoryType = null);
}