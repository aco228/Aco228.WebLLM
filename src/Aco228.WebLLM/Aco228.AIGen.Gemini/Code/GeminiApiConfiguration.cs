using Aco228.Common;
using Aco228.GoogleServices.Models;
using Aco228.GoogleServices.Services;
using Aco228.WService.Base;

namespace Aco228.AIGen.Gemini.Code;

public class GeminiApiConfiguration : ApiServiceConf
{
    private HttpClient _googleHttpClient;
    private readonly string ProjectId = null;
    private string Region = "europe-west1";
    public override string BaseUrl => $"https://aiplatform.googleapis.com/v1/projects/{ProjectId}/locations/{Region}/publishers/google/models/";

    public GeminiApiConfiguration(GoogleSetupOptions options)
    {
        ProjectId = options.ProjectId;
        _googleHttpClient = ServiceProviderHelper.GetService<IGoogleClientProvider>()!.GetGoogleHttpClient();
    }

    public override HttpClient Prepare(HttpClient httpClient)
    {
        return _googleHttpClient;
    }
}