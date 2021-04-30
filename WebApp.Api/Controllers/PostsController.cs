using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        private readonly IJsonPlaceholderApi _api;

        public PostsController(IJsonPlaceholderApi api)
        {
            _api = api;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            Post post = await _api.GetPost(id);

            return Ok(post);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Post> posts = await _api.GetPosts();

            return Ok(value: posts);
        }
    }
}
