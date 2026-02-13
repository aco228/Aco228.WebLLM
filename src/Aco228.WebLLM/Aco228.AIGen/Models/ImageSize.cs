namespace Aco228.AIGen.Models;

public enum ImageSize
{
    // 1:1
    Square,
    
    // 16:9, 3:2
    Portrait,
    
    // 9:16, 2:3
    Landscape,
}

public static class ImageSizeExtensions
{
    public static string ToDefaultSizeString(this ImageSize size)
    {
        return size switch
        {
            ImageSize.Square => "1024x1024",
            ImageSize.Portrait => "1024x1536",
            ImageSize.Landscape => "1536x1024",
            _ => throw new ArgumentOutOfRangeException(nameof(size), size, null)
        };
    }

    public static string ToDefaultAspectRatio(this ImageSize size)
    {
        return size switch
        {
            ImageSize.Square => "1:1",
            ImageSize.Portrait => "16:9",
            ImageSize.Landscape => "9:16",
            _ => throw new ArgumentOutOfRangeException(nameof(size), size, null)
        };
    }
}