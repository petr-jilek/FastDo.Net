namespace ApiCommon.Domain.Auth
{
    public class ErrorModel
    {
        public readonly string Message;
        public readonly int? Code;
        public readonly string? Detail;

        public ErrorModel(string message, int? code = null, string? detail = null)
        {
            Message = message;
            Code = code;
            Detail = detail;
        }
    }
}
