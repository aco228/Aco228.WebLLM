namespace Aco228.AIGen.Models;

public enum ImageSize
{
    Unknown = 0,
    
    // 1:1
    Square = 1,
    
    // 1:1
    MiniPortrait = 4,
    
    // 16:9, 3:2
    Portrait = 2,
    
    // 9:16, 2:3
    StoryReel = 3,
}

public static class ImageSizeExtensions
{
    public static string ToDefaultSizeString(this ImageSize size)
    {
        return size switch
        {
            ImageSize.Square => "1024x1024",
            ImageSize.Portrait => "1024x1536",
            ImageSize.MiniPortrait => "1080x1350",
            ImageSize.StoryReel => "1536x1024",
            _ => throw new ArgumentOutOfRangeException(nameof(size), size, null)
        };
    }

    public static string ToDefaultAspectRatio(this ImageSize size)
    {
        return size switch
        {
            ImageSize.Square => "1:1",
            ImageSize.Portrait => "16:9",
            ImageSize.MiniPortrait => "4:5",
            ImageSize.StoryReel => "9:16",
            _ => throw new ArgumentOutOfRangeException(nameof(size), size, null)
        };
    }
}