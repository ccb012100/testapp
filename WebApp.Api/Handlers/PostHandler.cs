using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WebApp.Api.Handlers.Requests;
using WebApp.Api.HttpClients;
using WebApp.Api.Models;

namespace WebApp.Api.Handlers
{
    // ReSharper disable once UnusedType.Global
    public class PostHandler : IRequestHandler<PostRequest, Post>
    {
        private readonly IJsonPlaceholderApi _api;

        public PostHandler(IJsonPlaceholderApi api)
        {
            _api = api;
        }

        public async Task<Post> Handle(PostRequest request, CancellationToken cancellationToken)
        {
            return await _api.GetPost(request.Id);
        }
    }
}
