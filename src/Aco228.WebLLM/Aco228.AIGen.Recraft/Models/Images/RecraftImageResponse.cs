namespace Aco228.AIGen.Recraft.Models.Images;

public class RecraftImageResponse
{
    public int created { get; set; }
    public int credits { get; set; }
    public List<DataDTO> data { get; set; }
}


public class DataDTO
{
    public string image_id { get; set; }
    public string url { get; set; }
}
