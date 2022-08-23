namespace ApiCommon.Domain.Consts
{
    public static class ApiCommonConsts
    {
        public const string DefaultLanguage = LanguageCodes.CZ;

        public static readonly List<string> SupportedLanguages = new List<string>() {
            LanguageCodes.CZ,
            LanguageCodes.EN,
            LanguageCodes.DE
        };
    }
}
