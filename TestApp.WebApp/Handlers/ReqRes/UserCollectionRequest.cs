using MediatR;
using TestApp.WebApp.Models.ReqRes;

namespace TestApp.WebApp.Handlers.ReqRes;

public record UserCollectionRequest : IRequest<CollectionResponse<User>>
{
    public UserCollectionRequest(int page)
    {
        Page = page;
    }

    public int Page { get; }
}
