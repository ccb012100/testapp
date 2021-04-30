using System.Collections.Generic;
using MediatR;
using WebApp.Api.Models;

namespace WebApp.Api.Handlers.Requests
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public record PostCollectionRequest : IRequest<IEnumerable<Post>>
    {
    }
}
