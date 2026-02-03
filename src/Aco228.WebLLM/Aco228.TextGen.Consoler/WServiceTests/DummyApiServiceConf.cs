using Aco228.WService;
using Aco228.WService.Attributes;
using Aco228.WService.Base;
using Aco228.WService.Exceptions;

namespace Aco228.TextGen.Consoler.WServiceTests;

public class DummyApiServiceConf : ApiServiceConf
{
    public override string BaseUrl => "https://jsonplaceholder.typicode.com/";

    public override void OnException(WebApiRequestException exception)
    {
        Console.WriteLine(exception.Message);
    }

    public override void OnBeforeRequest(WebApiMethodType methodType, ref string url, ref HttpContent? httpContent, string? httpContentString)
    {
        Console.WriteLine($"[{methodType}] {url} :: {httpContentString}");
    }
}