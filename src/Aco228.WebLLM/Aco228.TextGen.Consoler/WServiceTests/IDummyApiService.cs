using System.Text.Json.Serialization;
using Aco228.WService;
using Aco228.WService.Models.Attributes.MethodAttributes;

namespace Aco228.TextGen.Consoler.WServiceTests;

public class PostResponse
{
    public int userId { get; set; }
    public int id { get; set; }
    public string title { get; set; }
    public bool completed { get; set; }
}

public class FilterPosts
{
    public int userId { get; set; }
}

public class CreatePostRequest
{
    public string title { get; set; }
    public string body { get; set; }
    public int userId { get; set; } 
}

public class UpdatePostRequest
{
    public string title { get; set; }
    public string body { get; set; }
    public int userId { get; set; } 
}

public class PatchPostRequest
{
    [JsonPropertyName("title")]
    public string DasIstTitle { get; set; } 
}

public interface IDummyApiService : IDummyBase
{
    [ApiGet("todos/{id}")]
    Task<string> GetTodo(int id);

    [ApiGet("/posts")]
    Task<string> GetAllPosts();
    
    [ApiGet("/posts?{filterPosts}")]
    Task<string> FilterPosts(FilterPosts filterPosts);
    
    [ApiPost("/posts")]
    Task<PostResponse> CreatePost(CreatePostRequest req);

    [ApiPut("/posts/{id}")]
    Task<string> UpdatePost(int id, UpdatePostRequest req);
    
    [ApiPatch("/posts/{id}")]
    Task<string> PatchPost(int id, PatchPostRequest req);
    
    [ApiDelete("/posts/{id}")]
    Task DeletePost(int id);
    
}
