using System.Net;
using System.Text.Json;
using FastDo.Net.Domain.Consts;
using FastDo.Net.Domain.Errors.ErrorMessages;
using FastDo.Net.Domain.Exceptions;

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

        public async Task InvokeAsync(HttpContext context, IGetErrorMessage getErrorMessage)
        {
            try
            {
                await _next(context);
            }
            catch (AppException ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var errorModel = ex.GetErrorModel(getErrorMessage, GlobalConsts.DefaultLanguage);
                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var json = JsonSerializer.Serialize(errorModel, options);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
