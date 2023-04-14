namespace FastDo.Net.Domain.Errors
{
    public static class FastDoErrorCodes
    {
        public const string UnknownError = "0.0";
        public const string UndescribedError = "0.1";

        public const string Empty = "1.0";
        public const string ItemNotExists = "1.1";
        public const string ItemAlreadyExists = "1.2";
        public const string TextIsTooLong = "1.3";
        public const string TooMany = "1.4";
        public const string NotFound = "1.5";
        public const string CannotDelete = "1.6";
        public const string CannotCreate = "1.7";
        public const string AlreadyDeleted = "1.8";
        public const string InvalidData = "1.9";
        public const string InvalidControllerAction = "1.10";

        public const string EmailIsRequired = "2.0";
        public const string EmailIsNotValid = "2.1";
        public const string EmailIsTooLong = "2.2";
        public const string PasswordIsRequired = "2.3";
        public const string PasswordIsTooShort = "2.4";
        public const string PasswordIsTooLong = "2.5";
        public const string NewPasswordIsRequired = "2.6";
        public const string NewPasswordIsTooShort = "2.7";
        public const string NewPasswordIsTooLong = "2.8";
        public const string BadEmailOrPassword = "2.9";
        public const string BadPassword = "2.10";
        public const string PasswordsDontMatch = "2.11";
        public const string NameIsRequired = "2.12";
        public const string NameIsTooLong = "2.13";
        public const string PhoneNumberIsRequired = "2.14";
        public const string PhoneNumberIsNotValid = "2.15";
        public const string UserNameIsRequired = "2.16";
        public const string UserNameIsTooLong = "2.17";
        public const string ImageIsRequired = "2.18";
        public const string ImageNameIsTooLong = "2.19";
        public const string UserWithEmailAlreadyExists = "2.20";
        public const string TermsOfConditionsMustBeAccepted = "2.21";
        public const string EmailIsNotVerified = "2.22";
        public const string UserWithEmailDoesNotExists = "2.23";
        public const string PasswordRefreshFailed = "2.24";

        public const string FileIsEmpty = "3.0";
        public const string FileNameIsNotValid = "3.1";
        public const string FileTypeIsNotValid = "3.2";
        public const string FileIsNotValid = "3.3";
        public const string FileIsTooLarge = "3.4";
        public const string FileAlreadyExists = "3.5";
        public const string FileNotExists = "3.6";

        public const string EmailSendFailed = "4.0";
        public const string MustBePositiveNumber = "4.1";

        public const string ArticleNotExists = "5.0";
        public const string ArticleAlreadyExists = "5.1";
        public const string FundNotExists = "5.2";

        public const string EshopDoesNotExists = "6.0";
        public const string EshopWithSameNameAlreadyExists = "6.1";
        public const string TooManyEshopCreateRequestsInProgress = "6.2";
        public const string EshopCreateRequestNotExists = "6.3";
        public const string AtLeastOneExpeditionAddressItemMustBeProvided = "6.4";
        public const string ExpeditionTimesAreRequired = "6.5";
        public const string EshopNameIsRequired = "6.6";
        public const string EshopNameIsTooLong = "6.7";
        public const string EshopUrlIsRequired = "6.8";
        public const string EshopUrlIsTooLong = "6.9";
        public const string EshopUrlIsNotValid = "6.10";
        public const string EshopDescriptionIsRequired = "6.11";
        public const string EshopDescriptionIsTooLong = "6.12";
        public const string OrderDoesNotExists = "6.13";

        public const string DescriptionIsRequired = "7.0";
        public const string DescriptionIsTooLong = "7.1";
        public const string AddressIsRequired = "7.2";
        public const string StreetIsRequired = "7.3";
        public const string StreetNumberIsRequired = "7.4";
        public const string ZipCodeIsRequired = "7.5";
        public const string CityIsRequired = "7.6";
        public const string CountryIsRequired = "7.7";
        public const string CompanyNameIsRequired = "7.8";
        public const string CompanyNameIsTooLong = "7.9";
        public const string DicIsRequired = "7.10";
        public const string IcoIsRequired = "7.11";
        public const string IbanIsRequired = "7.12";
        public const string CompanyAddressIsRequired = "7.13";
        public const string CompanyInfoIsRequired = "7.14";

        public const string MustFillPreviousForms = "8.0";
        public const string AlreadySubmitted = "8.1";
        public const string MustFillForm = "8.2";
        public const string PaymentCreationFailed = "8.3";

        public const string StringIsTooLong = "9.0";
        public const string InputIsNotValid = "9.1";
        public const string AtLeastOneItemMustBeProvided = "9.2";
        public const string InvalidHexColorCode = "9.3";
    }
}
