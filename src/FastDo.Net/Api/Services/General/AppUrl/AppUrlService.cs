namespace FastDo.Net.Api.Services.General.AppUrl
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

        public string? CreateHttpsApiUrl(string path, bool useHttps = true)
        {
            if (useHttps)
                return $"https://{GetHostUrl()}/api{path}";
            else
                return $"http://{GetHostUrl()}/api{path}";
        }
        
        public string? CreateHttpsUrl(string path, bool useHttps = true)
        {
            if (useHttps)
                return $"https://{GetHostUrl()}{path}";
            else
                return $"http://{GetHostUrl()}{path}";
        }
    }
}
