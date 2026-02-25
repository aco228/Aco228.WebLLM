namespace Aco228.AIGen.DeepAI.Models.Web.CreateImage;

public class DeepAiCreateImageRequest
{
    public string text { get; set; }
    
    /// <summary>
    /// width, height
    /// Pass a string, eg "256" or "768" (default 512)
    ///     Use values between 128 and 1536.
    /// Width and height values must be multiples of 32.
    /// Recommended width and height for standard images are 1024x576, 1024x720, 512x512, 768x1024, 576x1024.
    ///     Recommended width and height for hd images are 1216x832, 1152x896, 1024x1024, 896x1152, 832x1216.
    ///     Note: values above approximately 700 or below 256 may produce strange outputs.
    /// </summary>
    public string width { get; set; } = "1024";
    public string height { get; set; } = "1024";
    
    /// <summary>
    /// Pass a string, either "standard" (default value), "hd", "genius", or "super_genius".
    /// </summary>
    public string image_generator_version { get; set; } = "hd";
    
    /// <summary>
    /// Can be used to enhance image quality and details.
    /// </summary>
    public string? negative_prompt { get; set; }
}