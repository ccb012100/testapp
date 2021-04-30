using MediatR;
using WebApp.Api.Models.ReqRes;

namespace WebApp.Api.Handlers.ReqRes
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public record UserRequest : IRequest<SingleItemResponse<User>>
    {
        public UserRequest(int id)
        {
            Id = id;
        }

        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public int Id { get; }
    }
}
