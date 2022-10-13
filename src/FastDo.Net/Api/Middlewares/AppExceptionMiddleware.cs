using System.Net;
using System.Text.Json;
using FastDo.Net.Domain.Consts;
using FastDo.Net.Domain.Error;

namespace FastDo.Net.Api.Middlewares
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
                _logger.LogError(ex, ex.Error);

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var errorModel = ErrorModels.GetErrorModel(ex.Error, GlobalConsts.DefaultLanguage);
                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var json = JsonSerializer.Serialize(errorModel, options);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
