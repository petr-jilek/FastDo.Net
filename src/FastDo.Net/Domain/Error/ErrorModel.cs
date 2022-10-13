namespace FastDo.Net.Domain.Error
{
    public class ErrorModel
    {
        public string Message { get; set; }
        public int? Code { get; set; }
        public string? Detail { get; set; }

        public ErrorModel(string message, int? code = null, string? detail = null)
        {
            Message = message;
            Code = code;
            Detail = detail;
        }
    }
}
