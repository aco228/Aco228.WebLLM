using System.Text.Json.Serialization;
using Aco228.AIGen.Models;

namespace Aco228.AIGen.ChatGPT.Models.Web.Texts;

public class CreateTextRequest : TextGenApiRequestBase<CreateTextRequest>
{
    [JsonPropertyName("model")]
    public string Model { get; set; } = "gpt-4.1";

    [JsonPropertyName("input")] 
    public List<InputDto> Input { get; set; } = new();

    public override CreateTextRequest UseModel(string? model)
    {
        if (string.IsNullOrEmpty(model))
            return this;
        
        Model = model;
        return this;
    }
    
    public override CreateTextRequest AddMessage(ModelRole role, string? content, List<string>? fileUrls = null)
    {
        if (string.IsNullOrEmpty(content))
            return this;
        
        Input.Add(new InputDto {role = role.ToString(), content = CreateContent(content, fileUrls)});
        return this;
    }

    private static List<InputDtoContent> CreateContent(string userPrompt, List<string>? fileUrls = null)
    {
        var res = new List<InputDtoContent> {new() {type = "input_text", text = userPrompt}};
        if(fileUrls != null && fileUrls.Any())
            foreach (var fileUrl in fileUrls)
                res.Add(new() {type = "input_image", image_url = new() { url = fileUrl}});
        
        return res;
    }
}


public class InputDto
{
    public string role { get; set; }
    public List<InputDtoContent> content { get; set; }
}

public class InputDtoContent
{
    public string type { get; set; }
    public string? text { get; set; }
    public InputDtoContentImageUrl? image_url { get; set; } = null;
}

public class InputDtoContentImageUrl
{
    public string url { get; set; }
}