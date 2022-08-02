namespace ApiCommon.Domain.Error
{
    public static class Errors
    {
        public static readonly ErrorModel UnkonwnError = new("UnkonwnError");
        public static readonly ErrorModel UndescriptedError = new("UndescriptedError");

        public static readonly ErrorModel BadEmail = new("BadEmail");
        public static readonly ErrorModel UserWithEmailAlreadyExists = new("UserWithEmailAlreadyExists");
        public static readonly ErrorModel BadUserName = new("BadUserName");
        public static readonly ErrorModel BadDisplayName = new("BadDisplayName");
        public static readonly ErrorModel BadPassword = new("BadPassword");
        public static readonly ErrorModel PasswordsDontMatch = new("PasswordsDontMatch");

        public static readonly ErrorModel RegistrationError = new("RegistrationError");
        public static readonly ErrorModel LoginError = new("LoginError");

        public static readonly ErrorModel EmailVerificationError = new("EmailVerificationError");

        public static readonly ErrorModel UserWithEmailDoesNotExists = new("UserWithEmailDoesNotExists");
        public static readonly ErrorModel AddToRoleError = new("AddToRoleError");

        public static readonly ErrorModel AlreadyExists = new("AlreadyExists");
        public static readonly ErrorModel TooMany = new("TooMany");

        public static readonly ErrorModel NotFound = new("NotFound");

        public static readonly ErrorModel CannotDelete = new("CannotDelete");
        public static readonly ErrorModel CannotDeleteIsMain = new("CannotDeleteIsMain");
        public static readonly ErrorModel CannotCreate = new("CannotCreate");
        public static readonly ErrorModel AlreadyDeleted = new("AlreadyDeleted");

        public static readonly ErrorModel InvalidData = new("InvalidData");

        public static readonly ErrorModel InvalidControllerAction = new("InvalidControllerAction");

        public static readonly ErrorModel GoPayError = new("GoPayError");
    }
}
