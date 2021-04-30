using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using WebApp.Api.Models.JsonPlaceholder;

namespace WebApp.Api.HttpClients
{
    public interface IJsonPlaceholderApi
    {
        [Get("/posts")]
        Task<IEnumerable<Post>> GetPosts();

        [Get("/posts/{id}")]
        Task<Post> GetPost(int id);
    }
}
