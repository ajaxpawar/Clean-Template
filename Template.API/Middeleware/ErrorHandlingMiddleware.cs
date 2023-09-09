using Microsoft.Data.SqlClient;
using System.Net;
using System.Text.Json;
using Template.API.Wrappers;
using Template.Application.Common.Exceptions;

namespace Template.API.Middeleware
{
    /// <summary>
    /// Handle all application errors
    /// </summary>
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
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

        private static async Task HandleException(HttpContext context,Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            string DisplayMsg = "Unable To Process Request";

            

            switch (error)
            {
                case ApiException e:
                    // custom application error
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    DisplayMsg = e.Message;
                    break;

                case KeyNotFoundException e:
                    // not found error
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    DisplayMsg = e.Message;
                    break;

                case  BadHttpRequestException e:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    DisplayMsg = "Bad Request";
                    break;

                default:
                    // unhandled error
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }
            var responseModel =  ApiResponse.Failure(response.StatusCode, DisplayMsg).ToResponse();

            var result = JsonSerializer.Serialize(responseModel);

            await response.WriteAsync(result);
        }
    }
}
