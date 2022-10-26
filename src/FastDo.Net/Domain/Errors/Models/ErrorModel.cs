namespace FastDo.Net.Domain.Errors.Models
{
    public class ErrorModel
    {
        public string Message { get; set; }
        public ErrorCode ErrorCode { get; set; }
        public string? Detail { get; set; }

        public ErrorModel(string message, ErrorCode errorCode, string? detail = null)
        {
            Message = message;
            ErrorCode = errorCode;
            Detail = detail;
        }
    }
}
