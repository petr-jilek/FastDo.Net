﻿using ApiCommon.Domain.Error;
using System.Net;

namespace ApiCommon.Application.Core
{
    public class Result<T>
    {
        public bool Success { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public T? Value { get; set; }
        public ErrorModel? Error { get; set; }

        public static Result<T> Ok() => new() { Success = true, StatusCode = HttpStatusCode.OK, Value = default, Error = null };
        public static Result<T> Ok(T value) => new() { Success = true, StatusCode = HttpStatusCode.OK, Value = value, Error = null };

        public static Result<T> BadRequest() => new() { Success = false, StatusCode = HttpStatusCode.BadRequest, Value = default, Error = null };
        public static Result<T> BadRequest(ErrorModel error) => new() { Success = false, StatusCode = HttpStatusCode.BadRequest, Value = default, Error = error };

        public static Result<T> NotFound() => new() { Success = false, StatusCode = HttpStatusCode.NotFound, Value = default, Error = null };
        public static Result<T> NotFound(ErrorModel error) => new() { Success = false, StatusCode = HttpStatusCode.NotFound, Value = default, Error = error };

        public static Result<T> Conflict() => new() { Success = false, StatusCode = HttpStatusCode.Conflict, Value = default, Error = null };
        public static Result<T> Conflict(ErrorModel error) => new() { Success = false, StatusCode = HttpStatusCode.NotFound, Value = default, Error = error };

        public static Result<T> Unauthorized() => new() { Success = false, StatusCode = HttpStatusCode.Unauthorized, Value = default, Error = null };
        public static Result<T> Unauthorized(ErrorModel error) => new() { Success = false, StatusCode = HttpStatusCode.Unauthorized, Value = default, Error = error };
    }
}