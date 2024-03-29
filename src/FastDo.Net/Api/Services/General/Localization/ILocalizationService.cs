﻿namespace FastDo.Net.Api.Services.General.Localization
{
    public interface ILocalizationService
    {
        public string GetLanguageCode();
        public string GetString(Dictionary<string, string> localizedValues);
    }
}
