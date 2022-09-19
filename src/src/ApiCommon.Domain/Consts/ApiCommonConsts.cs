namespace ApiCommon.Domain.Consts
{
    public static class ApiCommonConsts
    {
        public const string DefaultLanguage = LanguageCodes.Cz;

        public static readonly List<string> SupportedLanguages = new List<string>() {
            LanguageCodes.Cz,
            LanguageCodes.En,
            LanguageCodes.De
        };
    }
}
