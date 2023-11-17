using MediatR;
using WebApp.Models.ReqRes;

namespace WebApp.Handlers.ReqRes
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
