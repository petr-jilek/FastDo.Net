using ApiCommon.Application.Interfaces;

namespace ApiCommon.API.Services
{
    public class LocalizationService : ILocalizationService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LocalizationService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetLanguageCode()
        {
            var lang = _httpContextAccessor.HttpContext.Request.Headers["Accept-Language"];

            if (string.IsNullOrEmpty(lang))
                return "cz";

            return lang;
        }
    }
}
