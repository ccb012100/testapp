using MediatR;
using TestApp.WebApp.Models.JsonPlaceholder;

namespace TestApp.WebApp.Handlers.JsonPlaceholder;

public record PostRequest : IRequest<Post>
{
    public int Id { get; init; }
}
