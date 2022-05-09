using ApiCommon.Domain.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System.Net;
using System.Text.Json;

namespace ApiCommon.Domain.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHostEnvironment _env;
        public ExceptionMiddleware(RequestDelegate next, IHostEnvironment env)
        {
            _env = env;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = ex is AuthException exception
                    ? (_env.IsDevelopment()
                        ? new ErrorModel(exception.ErrorModel.Code, exception.ErrorModel.Message, ex.StackTrace?.ToString())
                        : exception.ErrorModel)
                    : (_env.IsDevelopment()
                        ? new ErrorModel(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString())
                        : new ErrorModel(context.Response.StatusCode, "Internal Server Error"));

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

                var json = JsonSerializer.Serialize(response, options);

                await context.Response.WriteAsync(json);
            }
        }
    }
}
