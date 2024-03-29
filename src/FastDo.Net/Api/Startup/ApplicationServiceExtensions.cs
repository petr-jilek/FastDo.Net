﻿using FastDo.Net.Api.Extensions;
using FastDo.Net.Api.Services.General.Localization;
using FastDo.Net.Application.Abstractions;
using FastDo.Net.Domain.Consts;
using FastDo.Net.Domain.Errors;
using FastDo.Net.Domain.Errors.ErrorMessages;
using FastDo.Net.Domain.Errors.Models;
using FastDo.Net.MongoDatabase.Providers;
using FastDo.Net.MongoDatabase.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FastDo.Net.Api.Startup
{
    public static class ApplicationServiceExtensions
    {
        private static IActionResult HandleErrors(ActionContext actionContext, IGetErrorMessage? getErrorMessage = null, IConfiguration? configuration = null)
        {
            var modelErrorCollection = actionContext.ModelState.Values
                .Where(_ => _.ValidationState == ModelValidationState.Invalid)
                .Select(_ => _.Errors)
                .FirstOrDefault();

            var lang = GlobalConsts.DefaultLanguage;

            if (configuration is not null)
            {
                var localizationServiceSettings = new LocalizationServiceSettings();
                configuration.GetSection(nameof(LocalizationServiceSettings))
                    .Bind(localizationServiceSettings);

                var httpContextAccessor = new HttpContextAccessor() { HttpContext = actionContext.HttpContext, };

                var localizationService = new LocalizationService(httpContextAccessor, localizationServiceSettings);

                lang = localizationService.GetLanguageCode();
            }

            if (getErrorMessage is null)
                getErrorMessage = new FastDoGetErrorMessage();

            var unknownErrorCode = (ErrorCode)FastDoErrorCodes.UnknownError;
            var unknownErrorModel = new ErrorModel(getErrorMessage.GetErrorMessage(unknownErrorCode, lang), unknownErrorCode);

            if (modelErrorCollection is null)
                return new BadRequestObjectResult(unknownErrorModel);

            var message = modelErrorCollection.FirstOrDefault()?.ErrorMessage;
            if (message is null)
                return new BadRequestObjectResult(unknownErrorModel);

            var errorCode = (ErrorCode)message;
            return new BadRequestObjectResult(new ErrorModel(getErrorMessage.GetErrorMessage(errorCode, lang), errorCode));
        }

        public static IServiceCollection AddApiBehaviorOptions(this IServiceCollection services, IGetErrorMessage? getErrorMessage = null)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    return HandleErrors(actionContext, getErrorMessage);
                };
            });

            return services;
        }

        public static IServiceCollection AddApiBehaviorOptionsLocalized(this IServiceCollection services, IConfiguration configuration, IGetErrorMessage? getErrorMessage = null)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    return HandleErrors(actionContext, getErrorMessage, configuration);
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

        public static IServiceCollection AddAllowAllCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(CorsPolicies.AllowAllCorsPolicy, policy =>
                {
                    policy
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowAnyOrigin();
                });
            });

            return services;
        }

        public static IServiceCollection AddAllowAllCorsPolicySignalR(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(CorsPolicies.AddAllowAllCorsPolicySignalR, policy =>
                {
                    policy
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .SetIsOriginAllowed(_ => true)
                        .AllowCredentials();
                });
            });

            return services;
        }

        public static IServiceCollection AddFastDoErrorMessages(this IServiceCollection services)
        {
            services.AddScoped<IGetErrorMessage, FastDoGetErrorMessage>();
            return services;
        }

        public static IServiceCollection AddErrorMessages<T>(this IServiceCollection services, bool addFastDoErrorMessages = true) where T : class, IGetErrorMessage
        {
            if (addFastDoErrorMessages)
                services.AddScoped<FastDoGetErrorMessage>();
            services.AddScoped<IGetErrorMessage, T>();
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

        public static IServiceCollection AddAuthorizedControllersWithHttpContextAccessor(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }
    }
}
