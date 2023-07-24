namespace FastDo.Net.Api.Services.General.Localization
{
    public interface ILocalizationService
    {
        public string GetLang();
        public string GetString(Dictionary<string, string> localizedValues);
    }
}
