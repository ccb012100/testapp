using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestApp.WebApp.Handlers.ReqRes;
using TestApp.WebApp.Models.ReqRes;

namespace TestApp.WebApp.Controllers;

public class UsersController : BaseController
{
    public UsersController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("page/{page:int}")]
    public async Task<ActionResult<CollectionResponse<User>>> GetUserPage(int page)
    {
        CollectionResponse<User> userPage = await Mediator.Send(new UserCollectionRequest(page)).ConfigureAwait(false);

        return Ok(userPage);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<SingleItemResponse<User>>> Get(int id)
    {
        SingleItemResponse<User> response = await Mediator.Send(new UserRequest(id)).ConfigureAwait(false);

        return Ok(response.Data);
    }
}
