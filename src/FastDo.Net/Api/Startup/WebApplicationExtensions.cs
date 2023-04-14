using FastDo.Net.Api.Middlewares;
using FastDo.Net.Domain.Consts;

namespace FastDo.Net.Api.Startup
{
    public class CreateDefaultPipelineOptions
    {
        public bool UseExceptionMiddleware { get; set; } = true;
        public bool UseAppExceptionMiddleware { get; set; } = true;
        public bool UseCorsPolicyInDevelopment { get; set; } = true;
        public string CorsPolicyInDevelopment { get; set; } = CorsPolicies.AllowAllCorsPolicy;
        public bool UseSwaggerBasicAuthMiddlewareInNotDevelopment { get; set; } = true;
        public bool UseSwagger { get; set; } = true;
        public bool UseSecurityHeaders { get; set; } = true;
        public bool UseDefaultFiles { get; set; } = true;
        public bool UseStaticFiles { get; set; } = true;
        public bool UseAuth { get; set; } = true;
        public bool MapControllers { get; set; } = true;
        public bool MapFallbackToController { get; set; } = true;
        public string FallbackAction { get; set; } = "Index";
        public string FallbackController { get; set; } = "Fallback";
    }

    public static class WebApplicationExtensions
    {
        public static WebApplication CreateDefaultPipeline(this WebApplication app, CreateDefaultPipelineOptions options, Action<WebApplication>? configurationBeforeFallback = null)
        {
            if (options.UseExceptionMiddleware)
                app.UseMiddleware<ExceptionMiddleware>();
            if (options.UseAppExceptionMiddleware)
                app.UseMiddleware<AppExceptionMiddleware>();

            if (options.UseCorsPolicyInDevelopment)
                if (app.Environment.IsDevelopment())
                    app.UseCors(options.CorsPolicyInDevelopment);

            if (options.UseSwaggerBasicAuthMiddlewareInNotDevelopment)
                if (app.Environment.IsDevelopment() == false)
                    app.UseMiddleware<SwaggerBasicAuthMiddleware>();

            if (options.UseSwagger)
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            if (options.UseSecurityHeaders)
            {
                app.UseXContentTypeOptions();
                app.UseReferrerPolicy(opt => opt.NoReferrer());
                app.UseXXssProtection(opt => opt.EnabledWithBlockMode());
                app.UseXfo(opt => opt.Deny());
            }

            if (options.UseDefaultFiles)
                app.UseDefaultFiles();
            if (options.UseStaticFiles)
                app.UseStaticFiles();

            if (options.UseAuth)
            {
                app.UseAuthentication();
                app.UseAuthorization();
            }

            if (options.MapControllers)
                app.MapControllers();

            if (configurationBeforeFallback is not null)
                configurationBeforeFallback.Invoke(app);

            if (options.MapFallbackToController)
                app.MapFallbackToController("Index", "Fallback");

            return app;
        }
    }
}
