using System.Text;
using ApiCommon.API.SecurityRequirements;
using ApiCommon.Domain.Consts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;

namespace ApiCommon.API.Startup
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityAuthentication(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey =
                            new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(configuration["TokenServiceSettings:Secret"])),
                        ValidateIssuer = true,
                        ValidIssuer = configuration["TokenServiceSettings:Issuer"],
                        ValidateAudience = true,
                        ValidAudience = configuration["TokenServiceSettings:Audience"],
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                });

            return services;
        }

        public static AuthorizationOptions AddSuperAdminUserActorAuthorizationPolicy(this AuthorizationOptions options)
        {
            options.AddPolicy(AuthorizePolicies.SuperAdminUserActor, policy =>
            {
                policy.Requirements.Add(new ActorRequirement(UserActors.SuperAdmin));
            });

            return options;
        }

        public static AuthorizationOptions AddVerifiedPhoneNumberAuthorizationPolicy(this AuthorizationOptions options)
        {
            options.AddPolicy(AuthorizePolicies.VerifiedPhoneNumber, policy =>
            {
                policy.Requirements.Add(new TrueClaimRequirement(new List<string>() { ApiCommonClaimTypes.PhoneNumberVerified }));
            });

            return options;
        }

        public static AuthorizationOptions AddVerifiedEmailAuthorizationPolicy(this AuthorizationOptions options)
        {
            options.AddPolicy(AuthorizePolicies.VerifiedEmail, policy =>
            {
                policy.Requirements.Add(new TrueClaimRequirement(new List<string>() { ApiCommonClaimTypes.EmailVerified }));
            });

            return options;
        }
    }
}
