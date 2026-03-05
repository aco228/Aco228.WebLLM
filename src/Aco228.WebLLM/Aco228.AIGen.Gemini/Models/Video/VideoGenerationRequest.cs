namespace Aco228.AIGen.Gemini.Models.Video;

public class VideoGenerationRequest
{
    public List<VideoGenerationRequestInstance> instances { get; set; } = new();
}

public class VideoGenerationRequestInstance
{
    public string prompt { get; set; }
}

public class VideoGenerationRequestParameters
{
    public string aspectRatio { get; set; } = "9:16";
    public int numberOfVideos  { get; set; } = 1;
    public bool personGeneration   { get; set; } = true;
    public string resolution { get; set; } = "720p";
}