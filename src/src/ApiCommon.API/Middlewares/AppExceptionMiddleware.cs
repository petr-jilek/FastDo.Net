using System.Net;
using System.Text.Json;
using ApiCommon.Domain.Error;

namespace ApiCommon.API.Middlewares
{
    public class AppExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<AppExceptionMiddleware> _logger;

        public AppExceptionMiddleware(RequestDelegate next, ILogger<AppExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (AppException ex)
            {
                _logger.LogError(ex, ex.ErrorModel.Message);

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

                var json = JsonSerializer.Serialize(ex.ErrorModel, options);

                await context.Response.WriteAsync(json);
            }
        }
    }
}
