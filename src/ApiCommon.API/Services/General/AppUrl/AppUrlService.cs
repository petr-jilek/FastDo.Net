namespace ApiCommon.API.Services.General.AppUrl
{
    public class AppUrlService : IAppUrlService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AppUrlService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string? GetHostUrl()
            => _httpContextAccessor.HttpContext?.Request.Host.Value;

        public string? CreateHttpsApiUrl(string path)
            => $"https://{GetHostUrl()}/api{path}";

        public string? CreateHttpsUrl(string path)
            => $"https://{GetHostUrl()}{path}";
    }
}
