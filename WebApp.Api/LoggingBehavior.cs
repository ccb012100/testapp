using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using WebApp.Api.Extensions;

namespace WebApp.Api
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            _logger.LogInformation($"REQUEST:{Environment.NewLine}{request.ToPrettyPrintJson()}");
            TResponse response = await next();
            _logger.LogInformation($"RESPONSE:{Environment.NewLine}{response.ToPrettyPrintJson()}");

            return response;
        }
    }
}
