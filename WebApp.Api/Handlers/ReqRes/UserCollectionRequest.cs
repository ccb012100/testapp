using MediatR;
using WebApp.Api.Models.ReqRes;

namespace WebApp.Api.Handlers.ReqRes
{
    public record UserCollectionRequest : IRequest<CollectionResponse<User>>
    {
        public UserCollectionRequest(int page)
        {
            Page = page;
        }

        public int Page { get; }
    }
}
