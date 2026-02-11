using Aco228.GoogleServices.Helpers;

namespace Aco228.AIGen.Gemini.Models.Gemini;

public class RequestText
{
    public List<RequestTextContent> contents { get; set; } = new();

    public RequestText AddContent(string role, string text, List<string>? imageFiles = null)
    {
        
        var content = new RequestTextContent() { role = role };
        var parts = new List<RequestTextContentPart>();
        
        parts.Add(new(){ text = text });
        
        content.parts.Add(new(){ text = text });
        if(imageFiles?.Any() == true)
            foreach (var imgUrl in imageFiles)
                content.parts.Add(new RequestTextContentPart()
                {
                    file_data = new()
                    {
                        file_uri = imgUrl,
                        mime_type = MimeTypeHelper.GetMimeTypeFromUrl(imgUrl)
                    }
                });
        
        contents.Add(content);
        return this;
    }
}

public class RequestTextContent
{
    public string role { get; set; }
    public List<RequestTextContentPart> parts { get; set; } = new();
}

public class RequestTextContentPart
{
    public string? text { get; set; }
    public RequestContentFileData? file_data { get; set; }
}

public class RequestContentFileData
{
    public string mime_type { get; set; }
    public string file_uri { get; set; }
}
