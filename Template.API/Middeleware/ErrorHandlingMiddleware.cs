using Microsoft.Data.SqlClient;
using System.Net;
using System.Text.Json;
using Template.API.Wrappers;
using Template.Application.Common.Exceptions;
using Template.Application.Services.Local_Services;

namespace Template.API.Middeleware
{
    /// <summary>
    /// Handle all application errors
    /// </summary>
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;
        private readonly IServiceProvider _serviceProvider;
        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger, IServiceProvider serviceProvider)
        {
            _next = next;
            _logger = logger;
            _serviceProvider = serviceProvider;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context,ex);
            }
           
        }

        private  async Task HandleException(HttpContext context,Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            string DisplayMsg = "Unable To Process Request";

            string _currenttime = GetDateTime();
            switch (error)
            {
                case ApiException e:
                    // custom application error
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    DisplayMsg = e.Message;
                    _logger.LogError(error, $"API Exception: {e.Message}, Timestamp: {_currenttime}");
                    break;

                case KeyNotFoundException e:
                    // not found error
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    DisplayMsg = e.Message;
                    _logger.LogWarning(error, $"Key Not Found Exception: {e.Message}, Timestamp: {_currenttime}");
                    break;

                case BadHttpRequestException e:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    DisplayMsg = "Bad Request";
                    _logger.LogError(error, $"Bad Request Exception, Timestamp: {_currenttime}");
                    break;

                default:
                    // unhandled error
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    _logger.LogError(error, $"Unhandled Exception, Timestamp: {_currenttime}");
                    break;
            }

            var responseModel =  ApiResponse.Failure(response.StatusCode, DisplayMsg).ToResponse();

            var result = JsonSerializer.Serialize(responseModel);

            await response.WriteAsync(result);
        }
        private  string GetDateTime()
        {
            var scope = _serviceProvider.CreateScope();
            var _currentdatetime = scope.ServiceProvider.GetService<IDateTimeService>();
            return  _currentdatetime.Now.ToString();
        }
    }
}
