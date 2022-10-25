using System.Net;
using System.Text.Json;
using FastDo.Net.Api.Services.General.Localization;
using FastDo.Net.Domain.Errors.ErrorMessages;
using FastDo.Net.Domain.Exceptions;

namespace FastDo.Net.Api.Middlewares
{
    public class AppExceptionLocalizedMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<AppExceptionLocalizedMiddleware> _logger;

        public AppExceptionLocalizedMiddleware(RequestDelegate next, ILogger<AppExceptionLocalizedMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, ILocalizationService localizationService, IGetErrorMessage getErrorMessage)
        {
            try
            {
                await _next(context);
            }
            catch (AppException ex)
            {
                _logger.LogError(ex, ex.Message);

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var errorModel = ex.GetErrorModel(getErrorMessage, localizationService.GetLanguageCode());
                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var json = JsonSerializer.Serialize(errorModel, options);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
