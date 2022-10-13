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

        public string GetLanguageCode()
        {
            var lang = _httpContextAccessor.HttpContext?.Request.Headers["Accept-Language"];

            if (lang is null || GlobalConsts.SupportedLanguages.Contains(lang) == false)
                return _settings.DefaultLanguage!;
            if (_settings.SupportedLanguages!.Contains(lang))
                return lang;

            return _settings.DefaultLanguage!;
        }

        public string GetString(Dictionary<string, string> localizedValues)
        {
            return localizedValues.TryGetValue(GetLanguageCode(), out var value) ? value : "##";
        }
    }
}
