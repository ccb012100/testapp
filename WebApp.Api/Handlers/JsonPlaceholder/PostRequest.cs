using MediatR;
using WebApp.Api.Models.JsonPlaceholder;

namespace WebApp.Api.Handlers.JsonPlaceholder
{
    public record PostRequest : IRequest<Post>
    {
        public int Id { get; init; }
    }
}
