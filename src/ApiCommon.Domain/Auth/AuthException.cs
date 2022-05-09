namespace ApiCommon.Domain.Auth
{
    public class AuthException : Exception
    {
        public readonly ErrorModel ErrorModel;

        public AuthException(ErrorModel errorModel)
        {
            ErrorModel = errorModel;
        }
    }
}
