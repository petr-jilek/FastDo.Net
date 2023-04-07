using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FastDo.Net.Api.Startup
{
    public static class SwaggerServiceExtensions
    {
        public static SwaggerGenOptions AddCustomSchemaIdsFuncSplitByDotTakeLast(this SwaggerGenOptions swaggerGenOptions, int takeLast = 3)
        {
            swaggerGenOptions.CustomSchemaIds((type) =>
            {
                if (type.FullName is null)
                    return "Unknown";

                var splittedFullName = type.FullName.Split('.');

                return string.Join("_", splittedFullName.TakeLast(takeLast));
            });

            return swaggerGenOptions;
        }

        public static string MapTypeToName(Type type)
        {
            if (type.FullName is null)
                return "Unknown";

            var splittedFullName = type.FullName.Split('.');

            return splittedFullName.Length switch
            {
                5 when splittedFullName[0] == "FastDo" && splittedFullName.Last() == "ErrorModel" => string.Join("_", splittedFullName.TakeLast(2)),
                _ => string.Join("_", splittedFullName.TakeLast(3))
            };
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services, string version = "v1",
            string title = "Title", string description = "An ASP.NET Core Web API", Func<Type, string>? modelNameFunc = null)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.CustomSchemaIds(_ =>
                {
                    if (modelNameFunc is null)
                        return MapTypeToName(_);
                    return modelNameFunc(_);
                });

                options.SwaggerDoc("v1",
                    new OpenApiInfo { Version = version, Title = title, Description = description, });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
            });

            return services;
        }
    }
}
