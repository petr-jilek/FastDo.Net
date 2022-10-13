using FastDo.Net.Api.Extensions;
using FastDo.Net.Api.Services.General.Localization;
using FastDo.Net.Application.Abstractions;
using FastDo.Net.Domain.Consts;
using FastDo.Net.Domain.Error;
using FastDo.Net.MongoDatabase.Providers;
using FastDo.Net.MongoDatabase.Settings;
using Microsoft.AspNetCore.Mvc;

namespace FastDo.Net.Api.Startup
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

                    var httpContextAccessor = new HttpContextAccessor() { HttpContext = actionContext.HttpContext, };

                    var lang = GlobalConsts.DefaultLanguage;

                    if (modelErrorCollection is null)
                        return new BadRequestObjectResult(ErrorModels.GetErrorModel(Errors.UnknownError, lang));

                    var message = modelErrorCollection.FirstOrDefault()?.ErrorMessage;

                    return message is null
                        ? new BadRequestObjectResult(ErrorModels.GetErrorModel(Errors.UnknownError, lang))
                        : new BadRequestObjectResult(ErrorModels.GetErrorModel(message, lang));
                };
            });

            return services;
        }

        public static IServiceCollection AddApiBehaviorOptionsLocalized(this IServiceCollection services,
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
                        return new BadRequestObjectResult(ErrorModels.GetErrorModel(Errors.UnknownError, lang));

                    var message = modelErrorCollection.FirstOrDefault()?.ErrorMessage;

                    return message is null
                        ? new BadRequestObjectResult(ErrorModels.GetErrorModel(Errors.UnknownError, lang))
                        : new BadRequestObjectResult(ErrorModels.GetErrorModel(message, lang));
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

        public static IServiceCollection AddFastDoHandlers(this IServiceCollection services)
        {
            services.AddByInterface<IHandler>();
            return services;
        }

        public static IServiceCollection AddMongo(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSettings<MongoDbSettings>(configuration);
            services.AddScoped<IMongoDbProvider, MongoDbProvider>();
            return services;
        }
    }
}
