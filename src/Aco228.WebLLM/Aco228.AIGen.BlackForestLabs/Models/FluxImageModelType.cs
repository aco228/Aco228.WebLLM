using Aco228.AIGen.Models;

namespace Aco228.AIGen.BlackForestLabs.Models;

public enum FluxImageModelType
{
    [ModelType("flux-2-klein-4b")]
    FluxKlein4b,
    
    [ModelType("flux-2-klein-9b")]
    FluxKlein9b,
    
    [ModelType("flux-2-pro")]
    Flux2Pro,
    
    [ModelType("flux-2-max")]
    Flux2Max,
    
    [ModelType("flux-2-flex")]
    Flux2Flex,
}