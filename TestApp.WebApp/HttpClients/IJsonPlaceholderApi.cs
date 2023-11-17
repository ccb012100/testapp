using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using TestApp.WebApp.Models.JsonPlaceholder;

namespace TestApp.WebApp.HttpClients;

public interface IJsonPlaceholderApi
{
    [Get("/posts")]
    Task<IEnumerable<Post>> GetPosts();

    [Get("/posts/{id}")]
    Task<Post> GetPost(int id);
}
