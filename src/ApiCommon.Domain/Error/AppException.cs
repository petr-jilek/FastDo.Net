namespace ApiCommon.Domain.Error
{
    public class AppException : Exception
    {
        public string? Error { get; set; }
        public string? ErrorDetail { get; set; }

        public AppException(string? error = null, string? errorDetail = null) : base()
        {
            Error = error;
            ErrorDetail = errorDetail;
        }
    }
}
