using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WebApp.HttpClients;
using WebApp.Models.JsonPlaceholder;

namespace WebApp.Handlers.JsonPlaceholder
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
