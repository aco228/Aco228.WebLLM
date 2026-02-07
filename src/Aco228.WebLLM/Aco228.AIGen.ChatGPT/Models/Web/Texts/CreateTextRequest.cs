using System.Text.Json.Serialization;
using Aco228.AIGen.Models;

namespace Aco228.AIGen.ChatGPT.Models.Web.Texts;

public class CreateTextRequest
{
    [JsonPropertyName("model")]
    public string Model { get; set; } = "gpt-4.1";

    [JsonPropertyName("input")] 
    public List<InputDto> Input { get; set; } = new();


    private static List<InputDtoContent> CreateContent(string userPrompt, List<string>? fileUrls = null)
    {
        var res = new List<InputDtoContent> {new() {type = "input_text", text = userPrompt}};
        if(fileUrls != null && fileUrls.Any())
            foreach (var fileUrl in fileUrls)
                res.Add(new() {type = "input_image", image_url = new() { url = fileUrl}});
        
        return res;
    }

    public CreateTextRequest AddInput(string role, string text, List<string>? imageUrls = null)
    {
        var input = new InputDto()
        {
            role = role
        };
        input.content.Add(new()
        {
            type = "input_text", 
            text = text
        });

        if (imageUrls != null && imageUrls.Any())
        {
            foreach (var imageUrl in imageUrls)
                input.content.Add(new() {type = "input_image", image_url = new() { url = imageUrl}});
        }
                
        Input.Add(input);
        return this;
    }
}


public class InputDto
{
    public string role { get; set; }
    public List<InputDtoContent> content { get; set; } = new();
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