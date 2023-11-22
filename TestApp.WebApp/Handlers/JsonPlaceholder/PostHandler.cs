using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TestApp.WebApp.HttpClients;
using TestApp.WebApp.Models.JsonPlaceholder;

namespace TestApp.WebApp.Handlers.JsonPlaceholder;

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
        return await _api.GetPost(request.Id).ConfigureAwait(false);
    }
}
