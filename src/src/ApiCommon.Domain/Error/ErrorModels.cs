namespace ApiCommon.Domain.Error
{
    public static class ErrorModels
    {
        public static ErrorModel GetErrorModel(string? errorCode, string lang)
        {
            if (errorCode is null)
                return lang switch
                {
                    "cz" => new ErrorModel("Neznámý error"),
                    "en" => new ErrorModel("Unknown error"),
                    "de" => new ErrorModel("Unbekannter Fehler"),
                    _ => new ErrorModel("Neznámý error"),
                };
            
            return errorCode switch
            {
                Errors.UnknownError => lang switch
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
                Errors.PasswordsDontMatch => lang switch
                {
                    "cz" => new ErrorModel("Hesla se neshodují"),
                    "en" => new ErrorModel("Passwords dont match"),
                    "de" => new ErrorModel("Passwörter stimmen nicht überein"),
                    _ => new ErrorModel("Hesla se neshodují"),
                },

                Errors.NameIsRequired => lang switch
                {
                    "cz" => new ErrorModel("Jméno je povinné"),
                    "en" => new ErrorModel("Name is required"),
                    "de" => new ErrorModel("Name ist erforderlich"),
                    _ => new ErrorModel("Jméno je povinné"),
                },
                Errors.NameIsTooLong => lang switch
                {
                    "cz" => new ErrorModel("Jméno je příliš dlouhé"),
                    "en" => new ErrorModel("Name is too long"),
                    "de" => new ErrorModel("Der Name ist zu lang"),
                    _ => new ErrorModel("Jméno je příliš dlouhé"),
                },

                Errors.PhoneNumberIsRequired => lang switch
                {
                    "cz" => new ErrorModel("Telefonní číslo je povinné"),
                    "en" => new ErrorModel("Phone number is required"),
                    "de" => new ErrorModel("Telefonnummer ist erforderlich"),
                    _ => new ErrorModel("Telefonní číslo je povinné"),
                },
                Errors.PhoneNumberIsNotValid => lang switch
                {
                    "cz" => new ErrorModel("Telefonní číslo není validní"),
                    "en" => new ErrorModel("Phone number is not valid"),
                    "de" => new ErrorModel("Die Telefonnummer ist ungültig"),
                    _ => new ErrorModel("Telefonní číslo není validní"),
                },

                Errors.EndDateMustBeGreaterThanStartDate => lang switch
                {
                    "cz" => new ErrorModel("Datum konce musí být větší, než datum začátku"),
                    "en" => new ErrorModel("The end date must be greater than the start date"),
                    "de" => new ErrorModel("Das Enddatum muss nach dem Startdatum liegen"),
                    _ => new ErrorModel("Datum konce musí být větší, než datum začátku"),
                },

                Errors.TextIsTooLong => lang switch
                {
                    "cz" => new ErrorModel("Text je příliš dlouhý"),
                    "en" => new ErrorModel("The text is too long"),
                    "de" => new ErrorModel("Der Text ist zu lang"),
                    _ => new ErrorModel("Text je příliš dlouhý"),
                },

                Errors.UnconfirmedReservationAlreadyExists => lang switch
                {
                    "cz" => new ErrorModel("Nepotvrzená rezervace již existuje"),
                    "en" => new ErrorModel("Unconfirmed reservation already exists"),
                    "de" => new ErrorModel("Es besteht bereits eine unbestätigte Reservierung"),
                    _ => new ErrorModel("Nepotvrzená rezervace již existuje"),
                },

                Errors.UserWithEmailAlreadyExists => lang switch
                {
                    "cz" => new ErrorModel("Uživatel s e-mailem již existuje"),
                    "en" => new ErrorModel("User with email already exists"),
                    "de" => new ErrorModel("Benutzer mit E-Mail existiert bereits"),
                    _ => new ErrorModel("Uživatel s e-mailem již existuje"),
                },

                Errors.Empty => lang switch
                {
                    "cz" => new ErrorModel("Prázdný"),
                    "en" => new ErrorModel("Empty"),
                    "de" => new ErrorModel("Leer"),
                    _ => new ErrorModel("Prázdný"),
                },

                Errors.FileIsEmpty => lang switch
                {
                    "cz" => new ErrorModel("Soubor je prázdný"),
                    "en" => new ErrorModel("File is empty"),
                    "de" => new ErrorModel("Die Datei ist leer"),
                    _ => new ErrorModel("Soubor je prázdný"),
                },
                Errors.FileNameIsNotValid => lang switch
                {
                    "cz" => new ErrorModel("Název souboru není platný"),
                    "en" => new ErrorModel("Dateiname ist ungültig"),
                    "de" => new ErrorModel("Die Datei ist leer"),
                    _ => new ErrorModel("Název souboru není platný"),
                },
                Errors.FileTypeIsNotValid => lang switch
                {
                    "cz" => new ErrorModel("Typ souboru není platný"),
                    "en" => new ErrorModel("File type is not valid"),
                    "de" => new ErrorModel("Dateityp ist ungültig"),
                    _ => new ErrorModel("Typ souboru není platný"),
                },
                Errors.FileIsTooLarge => lang switch
                {
                    "cz" => new ErrorModel("Soubor je příliš velký"),
                    "en" => new ErrorModel("File is too large"),
                    "de" => new ErrorModel("Datei ist zu groß"),
                    _ => new ErrorModel("Soubor je příliš velký"),
                },
                Errors.FileAlreadyExists => lang switch
                {
                    "cz" => new ErrorModel("Soubor již existuje"),
                    "en" => new ErrorModel("File already exists"),
                    "de" => new ErrorModel("Die Datei existiert bereits"),
                    _ => new ErrorModel("Soubor již existuje"),
                },
                Errors.FileNotExists => lang switch
                {
                    "cz" => new ErrorModel("Soubor neexistuje"),
                    "en" => new ErrorModel("File not exists"),
                    "de" => new ErrorModel("Datei existiert nicht"),
                    _ => new ErrorModel("Soubor neexistuje"),
                },

                Errors.ArticleNotExists => lang switch
                {
                    "cz" => new ErrorModel("Článek neexistuje"),
                    "en" => new ErrorModel("Article not exists"),
                    "de" => new ErrorModel("Artikel nicht vorhanden"),
                    _ => new ErrorModel("Článek neexistuje"),
                },
                Errors.ArticleAlreadyExists => lang switch
                {
                    "cz" => new ErrorModel("Článek již existuje"),
                    "en" => new ErrorModel("Article already exists"),
                    "de" => new ErrorModel("Artikel existiert bereits"),
                    _ => new ErrorModel("Článek již existuje"),
                },

                Errors.FundNotExists => lang switch
                {
                    "cz" => new ErrorModel("Fond neexistuje"),
                    "en" => new ErrorModel("Fund not exists"),
                    "de" => new ErrorModel("Fonds existiert nicht"),
                    _ => new ErrorModel("Fond neexistuje"),
                },

                Errors.UserNameIsRequired => lang switch
                {
                    "cz" => new ErrorModel("Uživatelské jméno je povinné"),
                    "en" => new ErrorModel("Username is required"),
                    "de" => new ErrorModel("Benutzername wird benötigt"),
                    _ => new ErrorModel("Uživatelské jméno je povinné"),
                },
                Errors.UserNameIsTooLong => lang switch
                {
                    "cz" => new ErrorModel("Uživatelské jméno je příliš dlouhé"),
                    "en" => new ErrorModel("Username is too long"),
                    "de" => new ErrorModel("Der Benutzername ist zu lang"),
                    _ => new ErrorModel("Uživatelské jméno je příliš dlouhé"),
                },

                Errors.ImageIsRequired => lang switch
                {
                    "cz" => new ErrorModel("Obrázek je povinný"),
                    "en" => new ErrorModel("Image is required"),
                    "de" => new ErrorModel("Bild ist erforderlich"),
                    _ => new ErrorModel("Obrázek je povinný"),
                },
                Errors.ImageNameIsTooLong => lang switch
                {
                    "cz" => new ErrorModel("Název obrázku je příliš dlouhý"),
                    "en" => new ErrorModel("Image name is too long"),
                    "de" => new ErrorModel("Bildname ist zu lang"),
                    _ => new ErrorModel("Název obrázku je příliš dlouhý"),
                },

                Errors.ItemNotExists => lang switch
                {
                    "cz" => new ErrorModel("Položka neexistuje"),
                    "en" => new ErrorModel("Item not exists"),
                    "de" => new ErrorModel("Artikel existiert nicht"),
                    _ => new ErrorModel("Položka neexistuje"),
                },
                Errors.ItemAlreadyExists => lang switch
                {
                    "cz" => new ErrorModel("Položka již existuje"),
                    "en" => new ErrorModel("Item already exists"),
                    "de" => new ErrorModel("Artikel existiert bereits"),
                    _ => new ErrorModel("Položka již existuje"),
                },

                Errors.EmailSendFailed => lang switch
                {
                    "cz" => new ErrorModel("Email se nepodařilo odeslat"),
                    "en" => new ErrorModel("The email could not be sent"),
                    "de" => new ErrorModel("Die E-Mail konnte nicht gesendet werden"),
                    _ => new ErrorModel("Email se nepodařilo odeslat"),
                },

                Errors.MustBePositiveNumber => lang switch
                {
                    "cz" => new ErrorModel("Musí být kladné číslo"),
                    "en" => new ErrorModel("Must be positive number"),
                    "de" => new ErrorModel("Muss eine positive Zahl sein"),
                    _ => new ErrorModel("Musí být kladné číslo"),
                },

                Errors.StartDateCannotBeInPast => lang switch
                {
                    "cz" => new ErrorModel("Datum začátku nemůže být v minulosti"),
                    "en" => new ErrorModel("Start date cannot be in past"),
                    "de" => new ErrorModel("Startdatum darf nicht in der Vergangenheit liegen"),
                    _ => new ErrorModel("Datum začátku nemůže být v minulosti"),
                },
                Errors.StartDateMustBeInFuture => lang switch
                {
                    "cz" => new ErrorModel("Datum začátku musí být v budoucnosti"),
                    "en" => new ErrorModel("The start date must be in the future"),
                    "de" => new ErrorModel("Das Startdatum muss in der Zukunft liegen"),
                    _ => new ErrorModel("Datum začátku musí být v budoucnosti"),
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
