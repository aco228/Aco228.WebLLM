namespace Aco228.TextGen.Claude.Models.Web.Text;

public abstract class RequestMessageEntry
{
    public abstract string type { get; }
    public string? text { get; set; }
    public RequestMessageEntryImageSource? source { get; set; }
}

#region Text

public class RequestMessageEntryText : RequestMessageEntry
{
    public override string type => "text";

    public RequestMessageEntryText(string input)
    {
        text = input;
    }
}

#endregion

#region Image

public class RequestMessageEntryImage : RequestMessageEntry
{
    public override string type => "image";

    public RequestMessageEntryImage(string url)
    {
        source = new RequestMessageEntryImageSource { url = url };
    }
}

public class RequestMessageEntryImageSource
{
    public string url { get; set; }
}

#endregion
