namespace Aco228.AIGen.Minimax.Models.Web.Image;

public class MinimaxImageRequest
{
    public string model { get; set; }
    public string prompt { get; set; }
    public string aspect_ratio { get; set; }
    public string response_format { get; set; } = "url";
    public int n { get; set; } = 1;
}