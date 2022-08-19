using System.Text.Json;
using ApiCommon.Domain.Error;

namespace ApiCommon.API.Middlewares
{
    public class ErrorLocalizationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<AppExceptionMiddleware> _logger;

        public ErrorLocalizationMiddleware(RequestDelegate next, ILogger<AppExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            await _next(context);

        }
    }
}
