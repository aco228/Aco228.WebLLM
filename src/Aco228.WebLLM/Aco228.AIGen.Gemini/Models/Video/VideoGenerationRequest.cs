namespace Aco228.AIGen.Gemini.Models.Video;

public class VideoGenerationRequest
{
    public List<VideoGenerationRequestInstance> instances { get; set; } = new();
    public VideoGenerationRequestParameters parameters { get; set; } = new();

    public void AddPrompt(string prompt)
    {
        instances.Add(new()
        {
            prompt = prompt,
        });
    }
}

public class VideoGenerationRequestInstance
{
    public string prompt { get; set; }
}

public class VideoGenerationRequestParameters
{
    public string aspectRatio { get; set; } = "9:16";
    public int durationSeconds  { get; set; } = 8;
    public string personGeneration { get; set; } = "allow_all";
    public string resolution { get; set; } = "720p";
}