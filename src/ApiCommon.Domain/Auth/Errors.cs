namespace ApiCommon.Domain.Auth
{
    public static class Errors
    {
        public static readonly ErrorModel BadEmail = new("bad_email");
        public static readonly ErrorModel UserWithEmailAlreadyExists = new("UserWithEmailAlreadyExists");
        public static readonly ErrorModel BadUserName = new("bad_user_name");
        public static readonly ErrorModel BadDisplayName = new("bad_display_name");
        public static readonly ErrorModel BadPassword = new("bad_password");
        public static readonly ErrorModel PasswordsDontMatch = new("passwords_dont_match");

        public static readonly ErrorModel UnkonwnError = new("unknown_error");

    }
}
