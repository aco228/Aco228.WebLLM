namespace Aco228.AIGen.Gemini.Models.Video;

public class VeoVideoStatusResponse
{
    public string name { get; set; }
    public bool done { get; set; }
    public VeoVideoStatusResponseResponseDTO? response { get; set; }
}


public class VeoVideoStatusResponseVideoDTO
{
    public string uri { get; set; }
}

public class VeoVideoStatusResponseGeneratedsampleDTO
{
    public VeoVideoStatusResponseVideoDTO video { get; set; }
}

public class GeneratevideoresponseDTO
{
    public List<VeoVideoStatusResponseGeneratedsampleDTO> generatedSamples { get; set; }
}

public class VeoVideoStatusResponseResponseDTO
{
    public GeneratevideoresponseDTO? generateVideoResponse { get; set; }
}
