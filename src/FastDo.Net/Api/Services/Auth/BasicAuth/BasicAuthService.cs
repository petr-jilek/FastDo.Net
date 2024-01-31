using System.Net.Http.Headers;
using System.Text;
using FastDo.Net.Domain.Models;

namespace FastDo.Net.Api.Services.Auth.BasicAuth
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
            string? authHeader = _httpContextAccessor.HttpContext!.Request.Headers["Authorization"];
            if (authHeader is null || authHeader.StartsWith("Basic ") == false)
                return null;

            var header = AuthenticationHeaderValue.Parse(authHeader);
            if (header.Parameter is null)
                return null;

            var inBytes = Convert.FromBase64String(header.Parameter);
            var credentials = Encoding.UTF8.GetString(inBytes).Split(':');
            if (credentials.Length != 2)
                return null;

            var userName = credentials[0];
            var password = credentials[1];

            return new BasicAuthCredentials()
            {
                UserName = userName,
                Password = password
            };
        }
    }
}
