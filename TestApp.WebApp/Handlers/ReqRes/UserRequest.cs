using MediatR;
using TestApp.WebApp.Models.ReqRes;

namespace TestApp.WebApp.Handlers.ReqRes;

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
