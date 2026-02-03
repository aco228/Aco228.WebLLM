using System.Text.Json.Serialization;
using Aco228.AIGen.Models;

namespace Aco228.AIGen.ChatGPT.Models.Web.Request;

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

    public override CreateTextRequest AddMessage(ModelRole role, string content)
    {
        if (string.IsNullOrEmpty(content))
            return this;
        
        Input.Add(new InputDto {role = role.ToString(), content = content});
        return this;
    }
}


public class InputDto
{
    public string role { get; set; }
    public string content { get; set; }
}