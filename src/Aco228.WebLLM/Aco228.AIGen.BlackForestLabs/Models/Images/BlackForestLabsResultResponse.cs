namespace Aco228.AIGen.BlackForestLabs.Models.Images;

public class BlackForestLabsResultResponse
{
    public string id { get; set; }
    public string status { get; set; }
    public ResultDTO? result { get; set; }
    public object progress { get; set; }
    public object details { get; set; }
    public object preview { get; set; }
}


public class ResultDTO
{
    public decimal start_time { get; set; }
    public string prompt { get; set; }
    public long seed { get; set; }
    public string sample { get; set; }
}
