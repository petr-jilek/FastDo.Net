using ApiCommon.Domain.Error;

namespace ApiCommon.API.Services.General.LocalizationService
{
    public interface ILocalizationService
    {
        public string GetLanguageCode();
        public string GetString(Dictionary<string, string> localizedValues);
        public ErrorModel GetErrorModel(string errorCode);
    }
}
