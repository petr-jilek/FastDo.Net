namespace ApiCommon.Domain.Error
{
    public class AppException : Exception
    {
        public ErrorModel ErrorModel { get; set; }

        public AppException(ErrorModel errorModel) : base()
        {
            ErrorModel = errorModel;
        }
    }
}
