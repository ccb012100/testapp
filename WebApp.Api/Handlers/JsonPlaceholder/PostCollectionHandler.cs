using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WebApp.Api.HttpClients;
using WebApp.Api.Models.JsonPlaceholder;

namespace WebApp.Api.Handlers.JsonPlaceholder
{
    // ReSharper disable once UnusedType.Global
    public class PostCollectionHandler : IRequestHandler<PostCollectionRequest, IEnumerable<Post>>
    {
        private readonly IJsonPlaceholderApi _api;

        public PostCollectionHandler(IJsonPlaceholderApi api)
        {
            _api = api;
        }

        public async Task<IEnumerable<Post>> Handle(PostCollectionRequest request, CancellationToken cancellationToken)
        {
            return await _api.GetPosts();
        }
    }
}
