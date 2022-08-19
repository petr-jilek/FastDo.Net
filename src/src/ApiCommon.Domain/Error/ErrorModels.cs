namespace ApiCommon.Domain.Error
{
    public static class ErrorModels
    {
        public static ErrorModel GetErrorModel(string errorCode, string lang)
        {
            return errorCode switch
            {
                Errors.UnkonwnError => lang switch
                {
                    "cz" => new ErrorModel("Neznámý error"),
                    "en" => new ErrorModel("Unknown error"),
                    "de" => new ErrorModel("Unbekannter Fehler"),
                    _ => new ErrorModel("Neznámý error"),
                },
                Errors.UndescribedError => lang switch
                {
                    "cz" => new ErrorModel("Nepopsaná chyba"),
                    "en" => new ErrorModel("Undescribed Error"),
                    "de" => new ErrorModel("Unbeschriebener Fehler"),
                    _ => new ErrorModel("Neznámý error 2"),
                },

                Errors.EmailIsRequired => lang switch
                {
                    "cz" => new ErrorModel("E-mail je povinný"),
                    "en" => new ErrorModel("Email is required"),
                    "de" => new ErrorModel("E-Mail ist erforderlich"),
                    _ => new ErrorModel("E-mail je povinný"),
                },
                Errors.EmailIsNotValid => lang switch
                {
                    "cz" => new ErrorModel("E-mail není validní"),
                    "en" => new ErrorModel("Email is not valid"),
                    "de" => new ErrorModel("Email ist ungültig"),
                    _ => new ErrorModel("E-mail není validní"),
                },
                Errors.EmailIsTooLong => lang switch
                {
                    "cz" => new ErrorModel("Email je příliš dlouhý"),
                    "en" => new ErrorModel("The email is too long"),
                    "de" => new ErrorModel("Die E-Mail ist zu lang"),
                    _ => new ErrorModel("Email je příliš dlouhý"),
                },

                Errors.PasswordIsRequired => lang switch
                {
                    "cz" => new ErrorModel("Heslo je povinné"),
                    "en" => new ErrorModel("Password is required"),
                    "de" => new ErrorModel("Passwort wird benötigt"),
                    _ => new ErrorModel("Heslo je povinné"),
                },
                Errors.PasswordIsTooShort => lang switch
                {
                    "cz" => new ErrorModel("Heslo je příliš krátké"),
                    "en" => new ErrorModel("Password is too short"),
                    "de" => new ErrorModel("Das Passwort ist zu kurz"),
                    _ => new ErrorModel("Heslo je příliš krátké"),
                },
                Errors.PasswordIsTooLong => lang switch
                {
                    "cz" => new ErrorModel("Heslo je příliš dlouhé"),
                    "en" => new ErrorModel("Password is too long"),
                    "de" => new ErrorModel("Passwort ist zu lang"),
                    _ => new ErrorModel("Heslo je příliš dlouhé"),
                },


                Errors.NewPasswordIsRequired => lang switch
                {
                    "cz" => new ErrorModel("Nové heslo je povinné"),
                    "en" => new ErrorModel("New password is required"),
                    "de" => new ErrorModel("Neues Passwort ist zu lang"),
                    _ => new ErrorModel("Nové heslo je povinné"),
                },
                Errors.NewPasswordIsTooShort => lang switch
                {
                    "cz" => new ErrorModel("Nové heslo je příliš krátké"),
                    "en" => new ErrorModel("New password is too short"),
                    "de" => new ErrorModel("Neues Passwort ist zu kurz"),
                    _ => new ErrorModel("Nové heslo je příliš krátké"),
                },
                Errors.NewPasswordIsTooLong => lang switch
                {
                    "cz" => new ErrorModel("Nové heslo je příliš dlouhé"),
                    "en" => new ErrorModel("New password is too long"),
                    "de" => new ErrorModel("Neues Passwort ist zu lang"),
                    _ => new ErrorModel("Nové heslo je příliš dlouhé"),
                },

                Errors.BadEmailOrPassword => lang switch
                {
                    "cz" => new ErrorModel("Špatné jméno nebo heslo"),
                    "en" => new ErrorModel("Bad email or password"),
                    "de" => new ErrorModel("Falscher Name oder falsches Passwort"),
                    _ => new ErrorModel("Špatné jméno nebo heslo"),
                },
                Errors.BadPassword => lang switch
                {
                    "cz" => new ErrorModel("Špatné heslo"),
                    "en" => new ErrorModel("Bad password"),
                    "de" => new ErrorModel("Falsches Passwort"),
                    _ => new ErrorModel("Špatné heslo"),
                },

                _ => lang switch
                {
                    "cz" => new ErrorModel("Neznámý error"),
                    "en" => new ErrorModel("Unknown error"),
                    "de" => new ErrorModel("Unbekannter Fehler"),
                    _ => new ErrorModel("Neznámý error"),
                },
            };
        }
    }
}
