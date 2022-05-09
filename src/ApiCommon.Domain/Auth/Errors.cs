namespace ApiCommon.Domain.Auth
{
    public static class Errors
    {
        public static readonly ErrorModel BadEmail = new(0, "bad_email");
        public static readonly ErrorModel UserWithEmailAlreadyExists = new(0, "UserWithEmailAlreadyExists");
        public static readonly ErrorModel BadUserName = new(10, "bad_user_name");
        public static readonly ErrorModel BadDisplayName = new(20, "bad_display_name");
        public static readonly ErrorModel BadPassword = new(30, "bad_password");
        public static readonly ErrorModel PasswordsDontMatch = new(40, "passwords_dont_match");
    }
}
