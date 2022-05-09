namespace ApiCommon.Domain.Auth
{
    public class ErrorModel
    {
        public readonly int Code;
        public readonly string Message;
        public readonly string? Detail;

        public ErrorModel(int code, string message, string? detail = null)
        {
            Code = code + 20_000;
            Message = message;
            Detail = detail;
        }
    }
}
