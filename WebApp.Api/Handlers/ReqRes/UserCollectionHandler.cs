using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using WebApp.Api.HttpClients;
using WebApp.Api.Models.ReqRes;

namespace WebApp.Api.Handlers.ReqRes
{
    // ReSharper disable once UnusedType.Global
    public class UserCollectionHandler : IRequestHandler<UserCollectionRequest, CollectionResponse<User>>
    {
        private readonly IReqResApi _api;
        private readonly ILogger<UserCollectionHandler> _logger;

        public UserCollectionHandler(IReqResApi api, ILogger<UserCollectionHandler> logger)
        {
            _api = api;
            _logger = logger;
        }

        public async Task<CollectionResponse<User>> Handle(UserCollectionRequest request,
            CancellationToken cancellationToken)
        {
            CollectionResponse<User> response = await _api.GetUsers(request.Page);
            return response;
        }
    }
}
