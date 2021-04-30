using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApp.Api.Handlers.Requests;
using WebApp.Api.Models;

namespace WebApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : BaseController
    {
        public PostsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            Post post = await Mediator.Send(new PostRequest {Id = id});

            return Ok(post);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Post> posts = await Mediator.Send(new PostCollectionRequest());

            return Ok(posts);
        }
    }
}
