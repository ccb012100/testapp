using System.Collections.Generic;
using MediatR;
using WebApp.Models.JsonPlaceholder;

namespace WebApp.Handlers.JsonPlaceholder
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public record PostCollectionRequest : IRequest<IEnumerable<Post>>
    {
    }
}
