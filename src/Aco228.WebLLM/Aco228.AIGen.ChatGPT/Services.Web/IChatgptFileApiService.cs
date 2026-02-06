using Aco228.AIGen.ChatGPT.Core;
using Aco228.AIGen.ChatGPT.Models.Web.Files;
using Aco228.WService;
using Aco228.WService.Models.Attributes.MethodAttributes;
using Aco228.WService.Models.Attributes.ParameterAttributes;

namespace Aco228.AIGen.ChatGPT.Services.Web;

/// <summary>
/// https://platform.openai.com/docs/api-reference/files/create
/// </summary>
public interface IChatgptFileApiService : IChatGptApiServiceBase
{
    [ApiDelete("v1/files/{fileId}")]
    Task<string> DeleteFile(string fileId);
    
    [ApiPost("v1/files")]
    Task<UploadFileDto> UploadFile(
        [ApiToForm] FileInfo file, 
        [ApiToForm] string purpose = "user_data");
}