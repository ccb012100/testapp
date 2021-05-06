using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using WebApp.Api.HttpClients;
using WebApp.Api.Models.ReqRes;

namespace WebApp.Api.Handlers.ReqRes
{
    // ReSharper disable once UnusedType.Global
    public class UserHandler : IRequestHandler<UserRequest, SingleItemResponse<User>>
    {
        private readonly IReqResApi _api;
        private readonly ILogger<UserHandler> _logger;

        public UserHandler(IReqResApi api, ILogger<UserHandler> logger)
        {
            _api = api;
            _logger = logger;
        }

        public async Task<SingleItemResponse<User>> Handle(UserRequest request, CancellationToken cancellationToken)
        {
            SingleItemResponse<User> response = await _api.GetUser(request.Id);
            return response;
        }
    }
}
