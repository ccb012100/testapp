using System.Collections.Generic;
using MediatR;
using TestApp.WebApp.Models.JsonPlaceholder;

namespace TestApp.WebApp.Handlers.JsonPlaceholder;

// ReSharper disable once ClassNeverInstantiated.Global
public record PostCollectionRequest : IRequest<IEnumerable<Post>>
{
}
