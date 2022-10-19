using FastDo.Net.Domain.Errors.Models;

namespace FastDo.Net.Domain.Errors.ErrorMessages
{
    public class FastDoGetErrorMessage : IGetErrorMessage
    {
        public string GetErrorMessage(ErrorCode errorCode, string lang)
        {
            return errorCode.Block switch
            {
                0 => Get0(errorCode, lang),
                1 => Get1(errorCode, lang),
                2 => Get2(errorCode, lang),
                3 => Get3(errorCode, lang),
                4 => Get4(errorCode, lang),
                _ => GetUnknownErrorMessage(lang),
            };
        }

        private string GetUnknownErrorMessage(string lang)
        {
            return lang switch
            {
                "cz" => "Neznámý error",
                "en" => "Unknown error",
                "de" => "Unbekannter Fehler",
                _ => "Neznámý error",
            };
        }

        private string Get0(ErrorCode errorCode, string lang)
        {
            return (string)errorCode switch
            {
                ErrorCodes.UnknownError => lang switch
                {
                    "cz" => "Neznámý error",
                    "en" => "Unknown error",
                    "de" => "Unbekannter Fehler",
                    _ => "Neznámý error",
                },
                ErrorCodes.UndescribedError => lang switch
                {
                    "cz" => "Nepopsaná chyba",
                    "en" => "Undescribed Error",
                    "de" => "Unbeschriebener Fehler",
                    _ => "Neznámý error 2",
                },
                _ => GetUnknownErrorMessage(lang),
            };
        }

        private string Get1(ErrorCode errorCode, string lang)
        {
            return (string)errorCode switch
            {

                _ => GetUnknownErrorMessage(lang),
            };
        }

        private string Get2(ErrorCode errorCode, string lang)
        {
            return (string)errorCode switch
            {

                _ => GetUnknownErrorMessage(lang),
            };
        }

        private string Get3(ErrorCode errorCode, string lang)
        {
            return (string)errorCode switch
            {

                _ => GetUnknownErrorMessage(lang),
            };
        }

        private string Get4(ErrorCode errorCode, string lang)
        {
            return (string)errorCode switch
            {

                _ => GetUnknownErrorMessage(lang),
            };
        }
    }
}
