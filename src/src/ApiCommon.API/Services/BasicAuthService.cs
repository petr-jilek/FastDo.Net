using System.Net.Http.Headers;
using System.Text;
using ApiCommon.Application.Interfaces;
using ApiCommon.Application.Models;

namespace ApiCommon.API.Services
{
    public class BasicAuthService : IBasicAuthService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BasicAuthService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public BasicAuthCredentials? GetBasicAuthCredentials()
        {
            string authHeader = _httpContextAccessor.HttpContext!.Request.Headers["Authorization"];
            if (authHeader is not null && authHeader.StartsWith("Basic "))
            {
                // Get the credentials from request header
                var header = AuthenticationHeaderValue.Parse(authHeader);

                if (header is not null && header.Parameter is not null)
                {
                    var inBytes = Convert.FromBase64String(header.Parameter);
                    var credentials = Encoding.UTF8.GetString(inBytes).Split(':');
                    var userName = credentials[0];
                    var password = credentials[1];

                    if (userName is null || password is null)
                        return null;

                    return new BasicAuthCredentials()
                    {
                        UserName = userName,
                        Password = password
                    };
                }
            }

            return null;
        }

    }
}
