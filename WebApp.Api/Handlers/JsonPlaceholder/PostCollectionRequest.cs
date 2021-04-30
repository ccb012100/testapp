using System.Collections.Generic;
using MediatR;
using WebApp.Api.Models.JsonPlaceholder;

namespace WebApp.Api.Handlers.JsonPlaceholder
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public record PostCollectionRequest : IRequest<IEnumerable<Post>>
    {
    }
}
