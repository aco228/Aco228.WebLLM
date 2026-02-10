namespace Aco228.AIGen.ChatGPT.Models.Web;

public class UsageDTO
{
    public int input_tokens { get; set; }
    public InputTokensDetailsDTO input_tokens_details { get; set; }
    public int output_tokens { get; set; }
    public OutputTokensDetailsDTO output_tokens_details { get; set; }
    public int total_tokens { get; set; }
}

public class InputTokensDetailsDTO
{
    public int text_tokens { get; set; }
    public int image_tokens { get; set; }
    public int cached_tokens { get; set; }
}

public class OutputTokensDetailsDTO
{
    public int reasoning_tokens { get; set; }
}