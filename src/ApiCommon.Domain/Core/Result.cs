using ApiCommon.Domain.Auth;
using System.Net;

namespace ApiCommon.Domain.Core
{
    public class Result<T>
    {
        public bool Success { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public T? Value { get; set; }
        public ErrorModel? Error { get; set; }

        public static Result<T> Ok(T value) => new() { Success = true, StatusCode = HttpStatusCode.OK, Value = value, Error = null };
        public static Result<T> BadRequest(ErrorModel error) => new() { Success = false, StatusCode = HttpStatusCode.BadRequest, Value = default, Error = error };
        public static Result<T> NotFound() => new() { Success = false, StatusCode = HttpStatusCode.NotFound, Value = default, Error = null };
        public static Result<T> Unauthorized(ErrorModel error) => new() { Success = false, StatusCode = HttpStatusCode.Unauthorized, Value = default, Error = error };
        public static Result<T> Unauthorized() => new() { Success = false, StatusCode = HttpStatusCode.Unauthorized, Value = default, Error = null };
    }
}
