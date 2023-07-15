using System.Net;

namespace FastDo.Net.Application.Core
{
    public class Result<T>
    {
        public bool Success { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public T? Value { get; set; }
        public string? ErrorCode { get; set; }
        public string? ErrorDetail { get; set; }

        public static Result<T> Ok() =>
            new() { Success = true, StatusCode = HttpStatusCode.OK, Value = default, ErrorCode = null };

        public static Result<T> Ok(T value) =>
            new() { Success = true, StatusCode = HttpStatusCode.OK, Value = value, ErrorCode = null };

        public static Result<T> BadRequest(string? errorCode = null, string? errorDetail = null, T? value = default) => new()
        {
            Success = false,
            StatusCode = HttpStatusCode.BadRequest,
            Value = value,
            ErrorCode = errorCode,
            ErrorDetail = errorDetail
        };

        public static Result<T> NotFound(string? errorCode = null, string? errorDetail = null, T? value = default) => new()
        {
            Success = false,
            StatusCode = HttpStatusCode.NotFound,
            Value = value,
            ErrorCode = errorCode,
            ErrorDetail = errorDetail
        };

        public static Result<T> Conflict(string? errorCode = null, string? errorDetail = null, T? value = default) => new()
        {
            Success = false,
            StatusCode = HttpStatusCode.Conflict,
            Value = value,
            ErrorCode = errorCode,
            ErrorDetail = errorDetail
        };

        public static Result<T> Unauthorized(string? errorCode = null, string? errorDetail = null, T? value = default) => new()
        {
            Success = false,
            StatusCode = HttpStatusCode.Unauthorized,
            Value = value,
            ErrorCode = errorCode,
            ErrorDetail = errorDetail
        };
    }
}
