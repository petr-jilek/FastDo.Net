using ApiCommon.Domain.Consts;
using ApiCommon.Domain.Error;

namespace ApiCommon.API.Services.General.LocalizationService
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

            if (lang is null || ApiCommonConsts.SupportedLanguages.Contains(lang) == false)
            {
                if (_settings.DefaultLanguage is not null)
                    return _settings.DefaultLanguage;

                return ApiCommonConsts.DefaultLanguage;
            }

            if (_settings.SupportedLanguages is not null && _settings.SupportedLanguages.Contains(lang))
                return lang;

            if (_settings.DefaultLanguage is not null)
                return _settings.DefaultLanguage;

            return ApiCommonConsts.DefaultLanguage;
        }

        public string GetString(Dictionary<string, string> localizedValues)
        {
            if (localizedValues.TryGetValue(GetLanguageCode(), out var value))
                return value;
            else
                return "##";
        }

        public ErrorModel GetErrorModel(string errorCode)
        {
            return ErrorModels.GetErrorModel(errorCode, GetLanguageCode());
        }
    }
}
