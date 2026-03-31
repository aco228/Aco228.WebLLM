namespace Aco228.TextGen.Claude.Models.Web.Text;

public class RequestMessageEntry
{
    public virtual string type { get; set; } = "text";
    public string? text { get; set; }
    public string? name { get; set; }
    public string? content { get; set; }
    public string? tool_use_id { get; set; }
    public string? id { get; set; }
    public Dictionary<string, string>? input { get; set; }
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
    public string type { get; } = "url";
    public string url { get; set; }
}

#endregion


public class RequestMessageEntryTool : RequestMessageEntry
{
    public override string type => "tool_result";
    public RequestMessageEntryTool(string id, string input)
    {
        tool_use_id = id;
        content = input;
    }
}

public class RequestMessageEntryToolRequest : RequestMessageEntry
{
    public override string type => "tool_use";
    public RequestMessageEntryToolRequest(string id, string name, Dictionary<string, string> input)
    {
        this.id = id;
        this.name = name;
        this.input = input;
    }
}