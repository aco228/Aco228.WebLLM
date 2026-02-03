using Aco228.WService.Attributes;
using Aco228.WService.Base;

namespace Aco228.TextGen.Consoler.WServiceTests;

[ApiServiceDecorator(Type = typeof(DummyApiServiceConf))]
public interface IDummyBase : IApiService
{
    
}