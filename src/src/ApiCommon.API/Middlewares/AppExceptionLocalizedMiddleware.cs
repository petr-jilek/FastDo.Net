using System.Net;
using System.Text.Json;
using ApiCommon.API.Services.General.Localization;
using ApiCommon.Domain.Error;

namespace ApiCommon.API.Middlewares
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

        public async Task InvokeAsync(HttpContext context, ILocalizationService localizationService)
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

                var errorModel = ErrorModels.GetErrorModel(ex.Error, localizationService.GetLanguageCode());
                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var json = JsonSerializer.Serialize(errorModel, options);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
