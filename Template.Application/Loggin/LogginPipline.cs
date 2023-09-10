using MediatR;
using Microsoft.Extensions.Logging;
using Template.Application.Services.Local_Services;

namespace Template.Application.Loggin
{
    public class LogginPipline<TReuest, TResponse>
        : IPipelineBehavior<TReuest, TResponse>
        where TReuest : IRequest<TResponse>
        where TResponse : class
    {
        private readonly ILogger<LogginPipline<TReuest, TResponse>> _logger;
        private readonly IDateTimeService _curentdatetime;

        public LogginPipline(ILogger<LogginPipline<TReuest, TResponse>> logger, IDateTimeService curentdatetime)
        {
            _logger = logger;
            _curentdatetime = curentdatetime;
        }

        public async Task<TResponse> Handle(TReuest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _logger.LogInformation($"Starting Request >> {typeof(TReuest).Name.ToString()} >> at >> {_curentdatetime.Now.ToString()}"
                );
            var result = await next();
            _logger.LogInformation($"Finished Request >> {typeof(TReuest).Name.ToString()} >> at >> {_curentdatetime.Now.ToString()}"
                );
            return result;
        }
    }
}
