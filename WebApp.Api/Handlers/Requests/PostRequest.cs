using MediatR;
using WebApp.Api.Models;

namespace WebApp.Api.Handlers.Requests
{
    public record PostRequest : IRequest<Post>
    {
        public int Id { get; init; }
    }
}
