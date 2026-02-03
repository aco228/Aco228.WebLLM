using Aco228.WService;
using Aco228.WService.Attributes;
using Aco228.WService.Base;
using Aco228.WService.Models.Attributes.MethodAttributes;

namespace Aco228.TextGen.Consoler.WServiceTests;


public class GithubApiServiceConfiguration : ApiServiceConf
{
    public override string BaseUrl => "https://api.github.com";
    public override string UserAgent => "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36";
}

[ApiServiceDecorator(Type =  typeof(GithubApiServiceConfiguration))]
public interface IGithubService : IApiService
{
    [ApiGet("users/{username}/repos")]
    Task<List<RepoSmallDTO>> GetRepos(string username);
}