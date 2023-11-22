using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestApp.WebApp.Handlers.JsonPlaceholder;
using TestApp.WebApp.Models.JsonPlaceholder;

namespace TestApp.WebApp.Controllers;

public class PostsController : BaseController
{
    public PostsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Post>> Get(int id)
    {
        Post post = await Mediator.Send(new PostRequest { Id = id }).ConfigureAwait(false);

        return Ok(post);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Post>>> Get()
    {
        IEnumerable<Post> posts = await Mediator.Send(new PostCollectionRequest()).ConfigureAwait(false);

        return Ok(posts);
    }
}
