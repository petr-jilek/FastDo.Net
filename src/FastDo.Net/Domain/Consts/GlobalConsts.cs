namespace FastDo.Net.Domain.Consts
{
    public static class GlobalConsts
    {
        public const string DefaultLanguage = LanguageCodes.Cz;

        public static readonly List<string> SupportedLanguages =
            new List<string>() { LanguageCodes.Cz, LanguageCodes.En, LanguageCodes.De };

        public const string MediaImagesFolder = "MediaImages";
        public const int MaxMediaImageSize = 5 * 1024 * 1024;
        public static readonly List<string> AllowedMediaImageExtensions = new List<string>() { "jpg", "png", "jpeg" };
    }
}
