using MediatR;
using WebApp.Models.JsonPlaceholder;

namespace WebApp.Handlers.JsonPlaceholder
{
    public record PostRequest : IRequest<Post>
    {
        public int Id { get; init; }
    }
}
