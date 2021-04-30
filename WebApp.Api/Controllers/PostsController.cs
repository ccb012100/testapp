using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApp.Api.Handlers.JsonPlaceholder;
using WebApp.Api.Models.JsonPlaceholder;

namespace WebApp.Api.Controllers
{
    public class PostsController : BaseController
    {
        public PostsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Post>> Get(int id)
        {
            Post post = await Mediator.Send(new PostRequest {Id = id});

            return Ok(post);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> Get()
        {
            IEnumerable<Post> posts = await Mediator.Send(new PostCollectionRequest());

            return Ok(posts);
        }
    }
}
