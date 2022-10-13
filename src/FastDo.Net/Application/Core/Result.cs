using System.Net;

namespace FastDo.Net.Application.Core
{
    public class Result<T>
    {
        public bool Success { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public T? Value { get; set; }
        public string? Error { get; set; }
        public string? ErrorDetail { get; set; }

        public static Result<T> Ok() =>
            new() { Success = true, StatusCode = HttpStatusCode.OK, Value = default, Error = null };

        public static Result<T> Ok(T value) =>
            new() { Success = true, StatusCode = HttpStatusCode.OK, Value = value, Error = null };

        public static Result<T> BadRequest(string? error = null, string? errorDetail = null) => new()
        {
            Success = false,
            StatusCode = HttpStatusCode.BadRequest,
            Value = default,
            Error = error,
            ErrorDetail = errorDetail
        };

        public static Result<T> NotFound(string? error = null, string? errorDetail = null) => new()
        {
            Success = false,
            StatusCode = HttpStatusCode.NotFound,
            Value = default,
            Error = error,
            ErrorDetail = errorDetail
        };

        public static Result<T> Conflict(string? error = null, string? errorDetail = null) => new()
        {
            Success = false,
            StatusCode = HttpStatusCode.Conflict,
            Value = default,
            Error = error,
            ErrorDetail = errorDetail
        };

        public static Result<T> Unauthorized(string? error = null, string? errorDetail = null) => new()
        {
            Success = false,
            StatusCode = HttpStatusCode.Unauthorized,
            Value = default,
            Error = error,
            ErrorDetail = errorDetail
        };
    }
}
