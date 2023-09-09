using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Template.Application.Services.Local_Services;

namespace Template.Infrastructure.Services.Local_Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            //set identity user id
            UserId = "System";
            IPAddress = httpContextAccessor.HttpContext?.Connection.RemoteIpAddress.ToString();
            if (string.IsNullOrEmpty(UserId))
                UserId = "System";
            if (string.IsNullOrEmpty(IPAddress))
                IPAddress = "127.0.0.1";
        }

        public string UserId { get; }
        public string IPAddress { get; }

    }
}
