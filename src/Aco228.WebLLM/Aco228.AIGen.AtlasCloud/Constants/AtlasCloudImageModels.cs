using Aco228.AIGen.Models;

namespace Aco228.AIGen.AtlasCloud.Constants;

internal static class AtlasCloudImageModels
{
    public static List<ModelImageDefinition> Models = new()
    {
        // Seedream (ByteDance)
        new ModelImageDefinition
        {
            Provider = ImageGenProvider.AtlasCloud, PriceLevel = PriceLevel.Low, Tier = ModelTier.Mid,
            Name = "Seedream v3", ModelApiName = "bytedance/seedream-v3", PricePerRequest = 0.027
        },
        new ModelImageDefinition
        {
            Provider = ImageGenProvider.AtlasCloud, PriceLevel = PriceLevel.Low, Tier = ModelTier.Mid,
            Name = "Seedream v3.1", ModelApiName = "bytedance/seedream-v3.1", PricePerRequest = 0.027
        },
        new ModelImageDefinition
        {
            Provider = ImageGenProvider.AtlasCloud, PriceLevel = PriceLevel.Low, Tier = ModelTier.Mid,
            Name = "Seedream v4", ModelApiName = "bytedance/seedream-v4", PricePerRequest = 0.02565
        },
        new ModelImageDefinition
        {
            Provider = ImageGenProvider.AtlasCloud, PriceLevel = PriceLevel.Mid, Tier = ModelTier.High,
            Name = "Seedream v4.5", ModelApiName = "bytedance/seedream-v4.5", PricePerRequest = 0.038
        },

        // Qwen Image T2I
        new ModelImageDefinition
        {
            Provider = ImageGenProvider.AtlasCloud, PriceLevel = PriceLevel.Low, Tier = ModelTier.Mid,
            Name = "Qwen Image T2I", ModelApiName = "atlascloud/qwen-image/text-to-image", PricePerRequest = 0.02
        },

        // Wan T2I
        new ModelImageDefinition
        {
            Provider = ImageGenProvider.AtlasCloud, PriceLevel = PriceLevel.Low, Tier = ModelTier.Mid,
            Name = "Wan 2.1 T2I", ModelApiName = "alibaba/wan-2.1/text-to-image", PricePerRequest = 0.02
        },

        // Z-Image Turbo
        new ModelImageDefinition
        {
            Provider = ImageGenProvider.AtlasCloud, PriceLevel = PriceLevel.Low, Tier = ModelTier.Low,
            Name = "Z-Image Turbo", ModelApiName = "z-image/turbo", PricePerRequest = 0.005
        },

        // Nano Banana (Google)
        new ModelImageDefinition
        {
            Provider = ImageGenProvider.AtlasCloud, PriceLevel = PriceLevel.Low, Tier = ModelTier.Mid,
            Name = "Nano Banana T2I", ModelApiName = "google/nano-banana/text-to-image", PricePerRequest = 0.03
        },
        new ModelImageDefinition
        {
            Provider = ImageGenProvider.AtlasCloud, PriceLevel = PriceLevel.Low, Tier = ModelTier.Mid,
            Name = "Nano Banana T2I Developer", ModelApiName = "google/nano-banana/text-to-image-developer",
            PricePerRequest = 0.019
        },
        new ModelImageDefinition
        {
            Provider = ImageGenProvider.AtlasCloud, PriceLevel = PriceLevel.High, Tier = ModelTier.High,
            Name = "Nano Banana Pro T2I", ModelApiName = "google/nano-banana-pro/text-to-image",
            PricePerRequest = 0.112
        },
        new ModelImageDefinition
        {
            Provider = ImageGenProvider.AtlasCloud, PriceLevel = PriceLevel.High, Tier = ModelTier.High,
            Name = "Nano Banana Pro T2I Ultra", ModelApiName = "google/nano-banana-pro/text-to-image-ultra",
            PricePerRequest = 0.15
        },

        // Imagen4 (Google)
        new ModelImageDefinition
        {
            Provider = ImageGenProvider.AtlasCloud, PriceLevel = PriceLevel.Low, Tier = ModelTier.Mid,
            Name = "Imagen4", ModelApiName = "google/imagen4", PricePerRequest = 0.038
        },
        new ModelImageDefinition
        {
            Provider = ImageGenProvider.AtlasCloud, PriceLevel = PriceLevel.Low, Tier = ModelTier.Low,
            Name = "Imagen4 Fast", ModelApiName = "google/imagen4-fast", PricePerRequest = 0.02
        },
        new ModelImageDefinition
        {
            Provider = ImageGenProvider.AtlasCloud, PriceLevel = PriceLevel.Mid, Tier = ModelTier.High,
            Name = "Imagen4 Ultra", ModelApiName = "google/imagen4-ultra", PricePerRequest = 0.06
        },
        new ModelImageDefinition
        {
            Provider = ImageGenProvider.AtlasCloud, PriceLevel = PriceLevel.Low, Tier = ModelTier.Mid,
            Name = "Imagen4 (AtlasCloud)", ModelApiName = "atlascloud/imagen4", PricePerRequest = 0.034
        },

        // HiDream
        new ModelImageDefinition
        {
            Provider = ImageGenProvider.AtlasCloud, PriceLevel = PriceLevel.Low, Tier = ModelTier.Mid,
            Name = "HiDream I1 Dev", ModelApiName = "atlascloud/hidream-i1-dev", PricePerRequest = 0.03
        },
        new ModelImageDefinition
        {
            Provider = ImageGenProvider.AtlasCloud, PriceLevel = PriceLevel.Mid, Tier = ModelTier.High,
            Name = "HiDream I1 Full", ModelApiName = "atlascloud/hidream-i1-full", PricePerRequest = 0.05
        },

        // Hunyuan
        new ModelImageDefinition
        {
            Provider = ImageGenProvider.AtlasCloud, PriceLevel = PriceLevel.High, Tier = ModelTier.High,
            Name = "Hunyuan Image 3", ModelApiName = "atlascloud/hunyuan-image-3", PricePerRequest = 0.1
        },

        // Neta Lumina
        new ModelImageDefinition
        {
            Provider = ImageGenProvider.AtlasCloud, PriceLevel = PriceLevel.Low, Tier = ModelTier.Low,
            Name = "Neta Lumina", ModelApiName = "atlascloud/neta-lumina", PricePerRequest = 0.01
        },

        // Ideogram
        new ModelImageDefinition
        {
            Provider = ImageGenProvider.AtlasCloud, PriceLevel = PriceLevel.Low, Tier = ModelTier.Mid,
            Name = "Ideogram v3 Turbo", ModelApiName = "ideogram-ai/ideogram-v3-turbo", PricePerRequest = 0.02
        },
        new ModelImageDefinition
        {
            Provider = ImageGenProvider.AtlasCloud, PriceLevel = PriceLevel.Mid, Tier = ModelTier.Mid,
            Name = "Ideogram v3 Balanced", ModelApiName = "ideogram-ai/ideogram-v3-balanced", PricePerRequest = 0.04
        },
        new ModelImageDefinition
        {
            Provider = ImageGenProvider.AtlasCloud, PriceLevel = PriceLevel.Mid, Tier = ModelTier.High,
            Name = "Ideogram v3 Quality", ModelApiName = "ideogram-ai/ideogram-v3-quality", PricePerRequest = 0.06
        },

        // Recraft
        new ModelImageDefinition
        {
            Provider = ImageGenProvider.AtlasCloud, PriceLevel = PriceLevel.Low, Tier = ModelTier.Mid,
            Name = "Recraft 20b", ModelApiName = "recraft-ai/recraft-20b", PricePerRequest = 0.022
        },
        new ModelImageDefinition
        {
            Provider = ImageGenProvider.AtlasCloud, PriceLevel = PriceLevel.Mid, Tier = ModelTier.High,
            Name = "Recraft v3", ModelApiName = "recraft-ai/recraft-v3", PricePerRequest = 0.04
        },
    };
}