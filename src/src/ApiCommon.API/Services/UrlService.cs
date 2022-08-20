using ApiCommon.Application.Interfaces;

namespace ApiCommon.API.Services
{
    public class UrlService : IUrlService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UrlService(IHttpContextAccessor httpContextAccessor)
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
