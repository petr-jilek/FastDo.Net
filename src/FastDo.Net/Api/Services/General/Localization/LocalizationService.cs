using FastDo.Net.Domain.Consts;

namespace FastDo.Net.Api.Services.General.Localization
{
    public class LocalizationService : ILocalizationService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly LocalizationServiceSettings _settings;

        public LocalizationService(IHttpContextAccessor httpContextAccessor, LocalizationServiceSettings settings)
        {
            _httpContextAccessor = httpContextAccessor;
            _settings = settings;
        }

        public string GetLang()
        {
            var langGet = _httpContextAccessor.HttpContext?.Request.Query["lang"];
            var langHeader = _httpContextAccessor.HttpContext?.Request.Headers["Accept-Language"];

            string? lang = langGet ?? langHeader ?? _settings.DefaultLanguage;

            if (string.IsNullOrEmpty(lang))
                lang = _settings.DefaultLanguage;
            if (GlobalConsts.SupportedLanguages.Contains(lang!) == false)
                lang = _settings.DefaultLanguage;

            return lang!;
        }

        public string GetString(Dictionary<string, string> localizedValues)
        {
            return localizedValues.TryGetValue(GetLang(), out var value) ? value : "##";
        }
    }
}
