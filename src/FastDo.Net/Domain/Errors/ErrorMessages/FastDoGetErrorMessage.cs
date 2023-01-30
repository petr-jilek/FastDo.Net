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
                5 => Get5(errorCode, lang),
                6 => Get6(errorCode, lang),
                7 => Get7(errorCode, lang),
                8 => Get8(errorCode, lang),
                9 => Get9(errorCode, lang),
                _ => GetUnknownErrorMessage(lang),
            };
        }

        public string GetUnknownErrorMessage(string lang)
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
                FastDoErrorCodes.UnknownError => lang switch
                {
                    "cz" => "Neznámý error",
                    "en" => "Unknown error",
                    "de" => "Unbekannter Fehler",
                    _ => "Neznámý error",
                },
                FastDoErrorCodes.UndescribedError => lang switch
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
                FastDoErrorCodes.Empty => lang switch
                {
                    "cz" => "Prázdný",
                    "en" => "Empty",
                    "de" => "Leer",
                    _ => "Prázdný",
                },
                FastDoErrorCodes.ItemNotExists => lang switch
                {
                    "cz" => "Položka neexistuje",
                    "en" => "Item not exists",
                    "de" => "Artikel existiert nicht",
                    _ => "Položka neexistuje",
                },
                FastDoErrorCodes.ItemAlreadyExists => lang switch
                {
                    "cz" => "Položka již existuje",
                    "en" => "Item already exists",
                    "de" => "Artikel existiert bereits",
                    _ => "Položka již existuje",
                },
                FastDoErrorCodes.TextIsTooLong => lang switch
                {
                    "cz" => "Text je příliš dlouhý",
                    "en" => "The text is too long",
                    "de" => "Der Text ist zu lang",
                    _ => "Text je příliš dlouhý",
                },
                FastDoErrorCodes.TooMany => lang switch
                {
                    "cz" => "Příliš mnoho",
                    "en" => "Too many",
                    "de" => "Zu viele",
                    _ => "Příliš mnoho",
                },
                FastDoErrorCodes.NotFound => lang switch
                {
                    "cz" => "Nenalezeno",
                    "en" => "Not found",
                    "de" => "Nicht gefunden",
                    _ => "Nenalezeno",
                },
                FastDoErrorCodes.CannotDelete => lang switch
                {
                    "cz" => "Nelze smazat",
                    "en" => "Cannot delete",
                    "de" => "Kann nicht löschen",
                    _ => "Nelze smazat",
                },
                FastDoErrorCodes.CannotCreate => lang switch
                {
                    "cz" => "Nelze vytvořit",
                    "en" => "Cannot create",
                    "de" => "Kann nicht erstellen",
                    _ => "Nelze vytvořit",
                },
                FastDoErrorCodes.AlreadyDeleted => lang switch
                {
                    "cz" => "Již smazáno",
                    "en" => "Already deleted",
                    "de" => "Bereits gelöscht",
                    _ => "Již smazáno",
                },
                FastDoErrorCodes.InvalidData => lang switch
                {
                    "cz" => "Neplatná data",
                    "en" => "Invalid data",
                    "de" => "Ungültige Daten",
                    _ => "Neplatná data",
                },
                FastDoErrorCodes.InvalidControllerAction => lang switch
                {
                    "cz" => "Neplatná akce ovladače",
                    "en" => "Invalid controller action",
                    "de" => "Ungültige Controller-Aktion",
                    _ => "Neplatná akce ovladače",
                },
                _ => GetUnknownErrorMessage(lang),
            };
        }

        private string Get2(ErrorCode errorCode, string lang)
        {
            return (string)errorCode switch
            {
                FastDoErrorCodes.EmailIsRequired => lang switch
                {
                    "cz" => "E-mail je povinný",
                    "en" => "Email is required",
                    "de" => "E-Mail ist erforderlich",
                    _ => "E-mail je povinný",
                },
                FastDoErrorCodes.EmailIsNotValid => lang switch
                {
                    "cz" => "E-mail není validní",
                    "en" => "Email is not valid",
                    "de" => "Email ist ungültig",
                    _ => "E-mail není validní",
                },
                FastDoErrorCodes.EmailIsTooLong => lang switch
                {
                    "cz" => "Email je příliš dlouhý",
                    "en" => "The email is too long",
                    "de" => "Die E-Mail ist zu lang",
                    _ => "Email je příliš dlouhý",
                },
                FastDoErrorCodes.PasswordIsRequired => lang switch
                {
                    "cz" => "Heslo je povinné",
                    "en" => "Password is required",
                    "de" => "Passwort wird benötigt",
                    _ => "Heslo je povinné",
                },
                FastDoErrorCodes.PasswordIsTooShort => lang switch
                {
                    "cz" => "Heslo je příliš krátké",
                    "en" => "Password is too short",
                    "de" => "Das Passwort ist zu kurz",
                    _ => "Heslo je příliš krátké",
                },
                FastDoErrorCodes.PasswordIsTooLong => lang switch
                {
                    "cz" => "Heslo je příliš dlouhé",
                    "en" => "Password is too long",
                    "de" => "Passwort ist zu lang",
                    _ => "Heslo je příliš dlouhé",
                },
                FastDoErrorCodes.NewPasswordIsRequired => lang switch
                {
                    "cz" => "Nové heslo je povinné",
                    "en" => " password is required",
                    "de" => "Neues Passwort ist zu lang",
                    _ => "Nové heslo je povinné",
                },
                FastDoErrorCodes.NewPasswordIsTooShort => lang switch
                {
                    "cz" => "Nové heslo je příliš krátké",
                    "en" => " password is too short",
                    "de" => "Neues Passwort ist zu kurz",
                    _ => "Nové heslo je příliš krátké",
                },
                FastDoErrorCodes.NewPasswordIsTooLong => lang switch
                {
                    "cz" => "Nové heslo je příliš dlouhé",
                    "en" => " password is too long",
                    "de" => "Neues Passwort ist zu lang",
                    _ => "Nové heslo je příliš dlouhé",
                },
                FastDoErrorCodes.BadEmailOrPassword => lang switch
                {
                    "cz" => "Špatné jméno nebo heslo",
                    "en" => "Bad email or password",
                    "de" => "Falscher Name oder falsches Passwort",
                    _ => "Špatné jméno nebo heslo",
                },
                FastDoErrorCodes.BadPassword => lang switch
                {
                    "cz" => "Špatné heslo",
                    "en" => "Bad password",
                    "de" => "Falsches Passwort",
                    _ => "Špatné heslo",
                },
                FastDoErrorCodes.PasswordsDontMatch => lang switch
                {
                    "cz" => "Hesla se neshodují",
                    "en" => "Passwords dont match",
                    "de" => "Passwörter stimmen nicht überein",
                    _ => "Hesla se neshodují",
                },
                FastDoErrorCodes.NameIsRequired => lang switch
                {
                    "cz" => "Jméno je povinné",
                    "en" => "Name is required",
                    "de" => "Name ist erforderlich",
                    _ => "Jméno je povinné",
                },
                FastDoErrorCodes.NameIsTooLong => lang switch
                {
                    "cz" => "Jméno je příliš dlouhé",
                    "en" => "Name is too long",
                    "de" => "Der Name ist zu lang",
                    _ => "Jméno je příliš dlouhé",
                },
                FastDoErrorCodes.PhoneNumberIsRequired => lang switch
                {
                    "cz" => "Telefonní číslo je povinné",
                    "en" => "Phone number is required",
                    "de" => "Telefonnummer ist erforderlich",
                    _ => "Telefonní číslo je povinné",
                },
                FastDoErrorCodes.PhoneNumberIsNotValid => lang switch
                {
                    "cz" => "Telefonní číslo není validní",
                    "en" => "Phone number is not valid",
                    "de" => "Die Telefonnummer ist ungültig",
                    _ => "Telefonní číslo není validní",
                },
                FastDoErrorCodes.UserNameIsRequired => lang switch
                {
                    "cz" => "Uživatelské jméno je povinné",
                    "en" => "Username is required",
                    "de" => "Benutzername wird benötigt",
                    _ => "Uživatelské jméno je povinné",
                },
                FastDoErrorCodes.UserNameIsTooLong => lang switch
                {
                    "cz" => "Uživatelské jméno je příliš dlouhé",
                    "en" => "Username is too long",
                    "de" => "Der Benutzername ist zu lang",
                    _ => "Uživatelské jméno je příliš dlouhé",
                },
                FastDoErrorCodes.ImageIsRequired => lang switch
                {
                    "cz" => "Obrázek je povinný",
                    "en" => "Image is required",
                    "de" => "Bild ist erforderlich",
                    _ => "Obrázek je povinný",
                },
                FastDoErrorCodes.ImageNameIsTooLong => lang switch
                {
                    "cz" => "Název obrázku je příliš dlouhý",
                    "en" => "Image name is too long",
                    "de" => "Bildname ist zu lang",
                    _ => "Název obrázku je příliš dlouhý",
                },
                FastDoErrorCodes.UserWithEmailAlreadyExists => lang switch
                {
                    "cz" => "Uživatel s e-mailem již existuje",
                    "en" => "User with email already exists",
                    "de" => "Benutzer mit E-Mail existiert bereits",
                    _ => "Uživatel s e-mailem již existuje",
                },
                FastDoErrorCodes.TermsOfConditionsMustBeAccepted => lang switch
                {
                    "cz" => "Obchodní podmínky musí být přijaty",
                    "en" => "Terms of conditions must be accepted",
                    "de" => "Die AGB müssen akzeptiert werden",
                    _ => "Obchodní podmínky musí být přijaty",
                },
                FastDoErrorCodes.EmailIsNotVerified => lang switch
                {
                    "cz" => "Email není ověřen",
                    "en" => "Email is not verified",
                    "de" => "E-Mail ist nicht verifiziert",
                    _ => "Email is not verified",
                },
                FastDoErrorCodes.UserWithEmailDoesNotExists => lang switch
                {
                    "cz" => "Uživatel s e-mailem neexistuje",
                    "en" => "User with email does not exists",
                    "de" => "Benutzer mit E-Mail existiert nicht",
                    _ => "Uživatel s e-mailem neexistuje",
                },
                FastDoErrorCodes.PasswordRefreshFailed => lang switch
                {
                    "cz" => "Obnova hesla selhala",
                    "en" => "Password refresh failed",
                    "de" => "Passwortaktualisierung fehlgeschlagen",
                    _ => "Obnova hesla selhala",
                },
                _ => GetUnknownErrorMessage(lang),
            };
        }

        private string Get3(ErrorCode errorCode, string lang)
        {
            return (string)errorCode switch
            {
                FastDoErrorCodes.FileIsEmpty => lang switch
                {
                    "cz" => "Soubor je prázdný",
                    "en" => "File is empty",
                    "de" => "Die Datei ist leer",
                    _ => "Soubor je prázdný",
                },
                FastDoErrorCodes.FileNameIsNotValid => lang switch
                {
                    "cz" => "Název souboru není platný",
                    "en" => "Dateiname ist ungültig",
                    "de" => "Die Datei ist leer",
                    _ => "Název souboru není platný",
                },
                FastDoErrorCodes.FileTypeIsNotValid => lang switch
                {
                    "cz" => "Typ souboru není platný",
                    "en" => "File type is not valid",
                    "de" => "Dateityp ist ungültig",
                    _ => "Typ souboru není platný",
                },
                FastDoErrorCodes.FileIsNotValid => lang switch
                {
                    "cz" => "Soubor není platný",
                    "en" => "File is not valid",
                    "de" => "Datei ist nicht gültig",
                    _ => "Soubor není platný",
                },
                FastDoErrorCodes.FileIsTooLarge => lang switch
                {
                    "cz" => "Soubor je příliš velký",
                    "en" => "File is too large",
                    "de" => "Datei ist zu groß",
                    _ => "Soubor je příliš velký",
                },
                FastDoErrorCodes.FileAlreadyExists => lang switch
                {
                    "cz" => "Soubor již existuje",
                    "en" => "File already exists",
                    "de" => "Die Datei existiert bereits",
                    _ => "Soubor již existuje",
                },
                FastDoErrorCodes.FileNotExists => lang switch
                {
                    "cz" => "Soubor neexistuje",
                    "en" => "File not exists",
                    "de" => "Datei existiert nicht",
                    _ => "Soubor neexistuje",
                },
                _ => GetUnknownErrorMessage(lang),
            };
        }

        private string Get4(ErrorCode errorCode, string lang)
        {
            return (string)errorCode switch
            {
                FastDoErrorCodes.EmailSendFailed => lang switch
                {
                    "cz" => "Email se nepodařilo odeslat",
                    "en" => "The email could not be sent",
                    "de" => "Die E-Mail konnte nicht gesendet werden",
                    _ => "Email se nepodařilo odeslat",
                },
                FastDoErrorCodes.MustBePositiveNumber => lang switch
                {
                    "cz" => "Musí být kladné číslo",
                    "en" => "Must be positive number",
                    "de" => "Muss eine positive Zahl sein",
                    _ => "Musí být kladné číslo",
                },
                _ => GetUnknownErrorMessage(lang),
            };
        }

        private string Get5(ErrorCode errorCode, string lang)
        {
            return (string)errorCode switch
            {
                FastDoErrorCodes.ArticleNotExists => lang switch
                {
                    "cz" => "Článek neexistuje",
                    "en" => "Article not exists",
                    "de" => "Artikel nicht vorhanden",
                    _ => "Článek neexistuje",
                },
                FastDoErrorCodes.ArticleAlreadyExists => lang switch
                {
                    "cz" => "Článek již existuje",
                    "en" => "Article already exists",
                    "de" => "Artikel existiert bereits",
                    _ => "Článek již existuje",
                },
                FastDoErrorCodes.FundNotExists => lang switch
                {
                    "cz" => "Fond neexistuje",
                    "en" => "Fund not exists",
                    "de" => "Fonds existiert nicht",
                    _ => "Fond neexistuje",
                },
                _ => GetUnknownErrorMessage(lang),
            };
        }

        private string Get6(ErrorCode errorCode, string lang)
        {
            return (string)errorCode switch
            {
                FastDoErrorCodes.EshopDoesNotExists => lang switch
                {
                    "cz" => "Eshop neexistuje",
                    "en" => "Eshop not exists",
                    "de" => "Eshop existiert nicht",
                    _ => "Eshop neexistuje",
                },
                FastDoErrorCodes.EshopWithSameNameAlreadyExists => lang switch
                {
                    "cz" => "Eshop s tímto názvem již existuje",
                    "en" => "Eshop with same name already exists",
                    "de" => "Eshop mit demselben Namen existiert bereits",
                    _ => "Eshop s tímto názvem již existuje",
                },
                FastDoErrorCodes.TooManyEshopCreateRequestsInProgress => lang switch
                {
                    "cz" => "Příliš mnoho eshopů jsou momentálně vytvářeny",
                    "en" => "Too many e-shops are being created",
                    "de" => "Es werden zu viele E-Shops erstellt",
                    _ => "Příliš mnoho eshopů jsou momentálně vytvářeny",
                },
                FastDoErrorCodes.EshopCreateRequestNotExists => lang switch
                {
                    "cz" => "Žádost o vytvoření eshopu neexistuje",
                    "en" => "Eshop create request not exists",
                    "de" => "Eshop-Anfrage existiert nicht",
                    _ => "Žádost o vytvoření eshopu neexistuje",
                },
                FastDoErrorCodes.AtLeastOneExpeditionAddressItemMustBeProvided => lang switch
                {
                    "cz" => "Musí být vyplněna alespoň jedna z expedičních adres",
                    "en" => "At least one of the shipping addresses must be filled in",
                    "de" => "Mindestens eine der Lieferadressen muss ausgefüllt werden",
                    _ => "Musí být vyplněna alespoň jedna z expedičních adres",
                },
                FastDoErrorCodes.ExpeditionTimesAreRequired => lang switch
                {
                    "cz" => "Časy expedice jsou povinné",
                    "en" => "Expedition times are required",
                    "de" => "Expeditionszeiten sind erforderlich",
                    _ => "Časy expedice jsou povinné",
                },
                FastDoErrorCodes.EshopNameIsRequired => lang switch
                {
                    "cz" => "Název eshopu je povinný",
                    "en" => "Eshop name is required",
                    "de" => "Eshop-Name ist erforderlich",
                    _ => "Název eshopu je povinný",
                },
                FastDoErrorCodes.EshopNameIsTooLong => lang switch
                {
                    "cz" => "Název eshopu je příliš dlouhý",
                    "en" => "Eshop name is too long",
                    "de" => "Eshop-Name ist zu lang",
                    _ => "Název eshopu je příliš dlouhý",
                },
                FastDoErrorCodes.EshopUrlIsRequired => lang switch
                {
                    "cz" => "Url eshopu je povinná",
                    "en" => "Eshop url is required",
                    "de" => "Eshop-URL ist erforderlich",
                    _ => "Url eshopu je povinná",
                },
                FastDoErrorCodes.EshopUrlIsTooLong => lang switch
                {
                    "cz" => "Url eshopu je příliš dlouhá",
                    "en" => "Eshop url is too long",
                    "de" => "Eshop-URL ist zu lang",
                    _ => "Url eshopu je příliš dlouhá",
                },
                FastDoErrorCodes.EshopUrlIsNotValid => lang switch
                {
                    "cz" => "Url eshopu není validní",
                    "en" => "Eshop url is not valid",
                    "de" => "Eshop-URL ist nicht gültig",
                    _ => "Url eshopu není validní",
                },
                FastDoErrorCodes.EshopDescriptionIsRequired => lang switch
                {
                    "cz" => "Popis eshopu je povinný",
                    "en" => "Eshop description is required",
                    "de" => "Eshop-Beschreibung ist erforderlich",
                    _ => "Popis eshopu je povinný",
                },
                FastDoErrorCodes.EshopDescriptionIsTooLong => lang switch
                {
                    "cz" => "Popis eshopu je příliš dlouhý",
                    "en" => "Eshop description is too long",
                    "de" => "Eshop-Beschreibung ist zu lang",
                    _ => "Popis eshopu je příliš dlouhý",
                },
                _ => GetUnknownErrorMessage(lang),
            };
        }

        private string Get7(ErrorCode errorCode, string lang)
        {
            return (string)errorCode switch
            {
                FastDoErrorCodes.DescriptionIsRequired => lang switch
                {
                    "cz" => "Popis je povinný",
                    "en" => "Description is required",
                    "de" => "Beschreibung ist erforderlich",
                    _ => "Popis je povinný",
                },
                FastDoErrorCodes.DescriptionIsTooLong => lang switch
                {
                    "cz" => "Popis je příliš dlouhý",
                    "en" => "Description is too long",
                    "de" => "Beschreibung ist zu lang",
                    _ => "Popis je příliš dlouhý",
                },
                FastDoErrorCodes.AddressIsRequired => lang switch
                {
                    "cz" => "Adresa je povinná",
                    "en" => "Address is required",
                    "de" => "Adresse ist erforderlich",
                    _ => "Adresa je povinná",
                },
                FastDoErrorCodes.StreetIsRequired => lang switch
                {
                    "cz" => "Ulice je povinná",
                    "en" => "Street is required",
                    "de" => "Straße ist erforderlich",
                    _ => "Ulice je povinná",
                },
                FastDoErrorCodes.StreetNumberIsRequired => lang switch
                {
                    "cz" => "Číslo domu je povinné",
                    "en" => "Street number is required",
                    "de" => "Hausnummer ist erforderlich",
                    _ => "Číslo domu je povinné",
                },
                FastDoErrorCodes.ZipCodeIsRequired => lang switch
                {
                    "cz" => "PSČ je povinné",
                    "en" => "Zip code is required",
                    "de" => "Postleitzahl ist erforderlich",
                    _ => "PSČ je povinné",
                },
                FastDoErrorCodes.CityIsRequired => lang switch
                {
                    "cz" => "Město je povinné",
                    "en" => "City is required",
                    "de" => "Stadt ist erforderlich",
                    _ => "Město je povinné",
                },
                FastDoErrorCodes.CountryIsRequired => lang switch
                {
                    "cz" => "Země je povinná",
                    "en" => "Country is required",
                    "de" => "Land ist erforderlich",
                    _ => "Země je povinná",
                },
                FastDoErrorCodes.CompanyNameIsRequired => lang switch
                {
                    "cz" => "Název firmy je povinný",
                    "en" => "Company name is required",
                    "de" => "Firmenname ist erforderlich",
                    _ => "Název firmy je povinný",
                },
                FastDoErrorCodes.CompanyNameIsTooLong => lang switch
                {
                    "cz" => "Název firmy je příliš dlouhý",
                    "en" => "Company name is too long",
                    "de" => "Firmenname ist zu lang",
                    _ => "Název firmy je příliš dlouhý",
                },
                FastDoErrorCodes.DicIsRequired => lang switch
                {
                    "cz" => "DIČ je povinné",
                    "en" => "DIC is required",
                    "de" => "DIC ist erforderlich",
                    _ => "DIČ je povinné",
                },
                FastDoErrorCodes.IcoIsRequired => lang switch
                {
                    "cz" => "IČO je povinné",
                    "en" => "ICO is required",
                    "de" => "ICO ist erforderlich",
                    _ => "IČO je povinné",
                },
                FastDoErrorCodes.IbanIsRequired => lang switch
                {
                    "cz" => "IBAN je povinné",
                    "en" => "IBAN is required",
                    "de" => "IBAN ist erforderlich",
                    _ => "IBAN je povinné",
                },
                FastDoErrorCodes.CompanyAddressIsRequired => lang switch
                {
                    "cz" => "Adresa firmy je povinná",
                    "en" => "Company address is required",
                    "de" => "Firmenadresse ist erforderlich",
                    _ => "Adresa firmy je povinná",
                },
                _ => GetUnknownErrorMessage(lang),
            };
        }

        private string Get8(ErrorCode errorCode, string lang)
        {
            return (string)errorCode switch
            {
                FastDoErrorCodes.MustFillPreviousForms => lang switch
                {
                    "cz" => "Musíte vyplnit předchozí formuláře",
                    "en" => "You must fill previous forms",
                    "de" => "Sie müssen die vorherigen Formulare ausfüllen",
                    _ => "Musíte vyplnit předchozí formuláře",
                },
                FastDoErrorCodes.AlreadySubmitted => lang switch
                {
                    "cz" => "Tento formulář byl již odeslán",
                    "en" => "This form has already been submitted",
                    "de" => "Dieses Formular wurde bereits abgeschickt",
                    _ => "Tento formulář byl již odeslán",
                },
                _ => GetUnknownErrorMessage(lang),
            };
        }

        private string Get9(ErrorCode errorCode, string lang)
        {
            return (string)errorCode switch
            {
                FastDoErrorCodes.StringIsTooLong => lang switch
                {
                    "cz" => "Vstup je příliš dlouhý",
                    "en" => "Input is too long",
                    "de" => "Eingabe ist zu lang",
                    _ => "Vstup je příliš dlouhý",
                },
                FastDoErrorCodes.InputIsNotValid => lang switch
                {
                    "cz" => "Vstup není platný",
                    "en" => "Input is not valid",
                    "de" => "Eingabe ist nicht gültig",
                    _ => "Vstup není platný",
                },
                FastDoErrorCodes.AtLeastOneItemMustBeProvided => lang switch
                {
                    "cz" => "Musíte vyplnit alespoň jednu položku",
                    "en" => "You must fill at least one item",
                    "de" => "Sie müssen mindestens ein Element ausfüllen",
                    _ => "Musíte vyplnit alespoň jednu položku",
                },
                _ => GetUnknownErrorMessage(lang),
            };
        }
    }
}
