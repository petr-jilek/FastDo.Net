using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace ApiCommon.Middlewares
{
    /// <summary>
    /// Middleware for Basic authorization
    /// </summary>
    public class BasicAuthMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="next"></param>
        public BasicAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// InvokeAsync
        /// </summary>
        /// <param name="context">HttpContext of the current request</param>
        /// <param name="configuration">Configuration from appsettings.json</param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context, IConfiguration configuration)
        {
            var paths = configuration.GetValue<List<string>>("BasicAuth:Paths");
            var authorize = false;

            foreach (var path in paths)
                if (context.Request.Path.StartsWithSegments(path))
                    authorize = true;

            if (authorize)
            {
                string authHeader = context.Request.Headers["Authorization"];
                if (authHeader is not null && authHeader.StartsWith("Basic "))
                {
                    // Get the credentials from request header
                    var header = AuthenticationHeaderValue.Parse(authHeader);

                    if (header is not null && header.Parameter is not null)
                    {
                        var inBytes = Convert.FromBase64String(header.Parameter);
                        var credentials = Encoding.UTF8.GetString(inBytes).Split(':');
                        var username = credentials[0];
                        var password = credentials[1];

                        var authUsername = configuration.GetValue<string>("BasicAuth:Username");
                        var authPassword = configuration.GetValue<string>("BasicAuth:Password");

                        // Validate credentials
                        if (username.Equals(authUsername) && password.Equals(authPassword))
                        {
                            await _next.Invoke(context).ConfigureAwait(false);
                            return;
                        }
                    }
                }
                context.Response.Headers["WWW-Authenticate"] = "Basic";
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            else
            {
                await _next.Invoke(context).ConfigureAwait(false);
            }
        }
    }
}
