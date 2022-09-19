using ApiCommon.API.Extensions;
using ApiCommon.API.Services.General;
using ApiCommon.Application.Abstractions;
using ApiCommon.Application.Services.Settings.General;
using ApiCommon.Domain.Consts;
using ApiCommon.Domain.Error;
using Microsoft.AspNetCore.Mvc;

namespace ApiCommon.API.Startup
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApiBehaviorOptions(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var modelErrorCollection = actionContext.ModelState.Values.Select(x => x.Errors).FirstOrDefault();

                    var localizationServiceSettings = new LocalizationServiceSettings();
                    configuration.GetSection(nameof(LocalizationServiceSettings))
                        .Bind(localizationServiceSettings);

                    var httpContextAccessor = new HttpContextAccessor() { HttpContext = actionContext.HttpContext, };

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

        public static IServiceCollection AddReactDevelopmentCorsPolicy(this IServiceCollection services,
            int port = 3000)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(CorsPolicies.ReactFrontendDevelopment, policy =>
                {
                    policy
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .WithOrigins($"http://localhost:{port}");
                });
            });

            return services;
        }
        
        public static IServiceCollection AddApiCommonHandlers(this IServiceCollection services)
        {
            services.AddByInterface<IHandler>();
            return services;
        }
    }
}
