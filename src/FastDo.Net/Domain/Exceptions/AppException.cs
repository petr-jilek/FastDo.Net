namespace FastDo.Net.Domain.Exceptions
{
    public class AppException : Exception
    {
        public string? ErrorCode { get; set; }
        public string? ErrorDetail { get; set; }

        public AppException(string? errorCode = null, string? errorDetail = null) : base()
        {
            ErrorCode = errorCode;
            ErrorDetail = errorDetail;
        }
    }
}
