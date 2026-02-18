using Aco228.WService.Attributes;
using Aco228.WService.Base;

namespace Aco228.AIGen.AtlasCloud.Core;

[ApiServiceDecorator(typeof(AtlasCloudServiceConfiguration))]
public interface IAtlasCloudApiService : IApiService
{
    
}