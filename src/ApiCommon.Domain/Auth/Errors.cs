namespace ApiCommon.Domain.Auth
{
    public static class Errors
    {
        public static readonly ErrorModel BadEmail = new("BadEmail");
        public static readonly ErrorModel UserWithEmailAlreadyExists = new("UserWithEmailAlreadyExists");

        public static readonly ErrorModel BadUserName = new("BadUserName");
        public static readonly ErrorModel BadDisplayName = new("BadDisplayName");
        public static readonly ErrorModel BadPassword = new("BadPassword");
        public static readonly ErrorModel PasswordsDontMatch = new("PasswordsDontMatch");

        public static readonly ErrorModel RegistrationError = new("RegistrationError");
        public static readonly ErrorModel LoginError = new("LoginError");

        public static readonly ErrorModel UserWithEmailDoesNotExists = new("UserWithEmailDoesNotExists");


        public static readonly ErrorModel UnkonwnError = new("UnkonwnError");

    }
}
