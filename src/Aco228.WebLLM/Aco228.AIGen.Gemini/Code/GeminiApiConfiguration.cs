using Aco228.Common;
using Aco228.GoogleServices.Services;
using Aco228.WService.Base;

namespace Aco228.AIGen.Gemini.Code;

public class GeminiApiConfiguration : ApiServiceConf
{
    private HttpClient _googleHttpClient;
    private readonly string ProjectId = null;
    public override string BaseUrl => $"https://aiplatform.googleapis.com/v1/projects/{ProjectId}/locations/europe-west1/publishers/google/models/";

    public GeminiApiConfiguration()
    {
        ProjectId = Environment.GetEnvironmentVariable("GOOGLE_PROJECT_ID") 
                    ?? throw new InvalidOperationException("GeminiProjectId is not set");

        _googleHttpClient = ServiceProviderHelper.GetService<IGoogleClientProvider>()!.GetGoogleHttpClient();
    }

    public override HttpClient Prepare(HttpClient httpClient)
    {
        return _googleHttpClient;
    }
}