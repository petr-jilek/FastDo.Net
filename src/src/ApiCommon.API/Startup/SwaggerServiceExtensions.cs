﻿using Microsoft.OpenApi.Models;

namespace ApiCommon.API.Startup
{
    public static class SwaggerServiceExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services, string version = "v1",
            string title = "Title", string description = "An ASP.NET Core Web API")
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.CustomSchemaIds(_ =>
                {
                    if (_.FullName is null)
                        return "Unknown";

                    var splittedFullName = _.FullName.Split('.');

                    return splittedFullName.Length switch
                    {
                        > 3 when splittedFullName[0] == "Application" => string.Join("_", splittedFullName.Skip(3)),
                        4 when splittedFullName[2] == "Error" => splittedFullName[2] + "_" + splittedFullName[3],
                        _ => string.Join("_", splittedFullName)
                    };
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