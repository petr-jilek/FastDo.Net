using ApiCommon.Domain.Error;

namespace ApiCommon.Application.Interfaces
{
    public interface ILocalizationService
    {
        public string GetLanguageCode();
        public string GetString(Dictionary<string, string> localizedValues);
        public ErrorModel GetErrorModel(string errorCode);
    }
}
