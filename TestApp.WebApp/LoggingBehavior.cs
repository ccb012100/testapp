using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using TestApp.WebApp.Extensions;

namespace TestApp.WebApp;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _logger.LogDebug("REQUEST: {Request}", request.ToPrettyPrintJson());
        TResponse response = await next().ConfigureAwait(false);
        _logger.LogDebug("RESPONSE: {Response}", response.ToPrettyPrintJson());

        return response;
    }
}
