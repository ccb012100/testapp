using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;

namespace WebApp.Api
{
    public interface IJsonPlaceholderApi
    {
        [Get("/posts")]
        Task<IEnumerable<Post>> GetPosts();

        [Get("/posts/{id}")]
        Task<Post> GetPost(int id);
    }
}
