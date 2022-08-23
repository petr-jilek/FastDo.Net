using ApiCommon.API.Services;
using ApiCommon.Application.ServiceSettings;
using ApiCommon.Domain.Error;
using Microsoft.AspNetCore.Mvc;

namespace ApiCommon.API.Startup
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApiBehaviorOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var modelErrorCollection = actionContext.ModelState.Values.Select(x => x.Errors).FirstOrDefault();

                    var localizationServiceSettings = new LocalizationServiceSettings();
                    configuration.GetSection(typeof(LocalizationServiceSettings).Name).Bind(localizationServiceSettings);

                    var httpContextAccessor = new HttpContextAccessor()
                    {
                        HttpContext = actionContext.HttpContext,
                    };

                    var localizationService = new LocalizationService(httpContextAccessor, localizationServiceSettings);

                    var lang = localizationService.GetLanguageCode();

                    if (modelErrorCollection is null)
                        return new BadRequestObjectResult(ErrorModels.GetErrorModel(Errors.UnkonwnError, lang));

                    var message = modelErrorCollection.FirstOrDefault()?.ErrorMessage;

                    if (message is null)
                        return new BadRequestObjectResult(ErrorModels.GetErrorModel(Errors.UnkonwnError, lang));

                    return new BadRequestObjectResult(ErrorModels.GetErrorModel(message, lang));
                };
            });

            return services;
        }
    }
}
