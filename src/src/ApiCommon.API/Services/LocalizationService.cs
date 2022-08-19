using ApiCommon.Application.Interfaces;
using ApiCommon.Domain.Error;

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
