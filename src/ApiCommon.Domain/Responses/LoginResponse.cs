namespace ApiCommon.Domain.Responses
{
    public class LoginResponse<T>
    {
        public string? Token { get; set; }
        public T? UserData { get; set; }
    }
}
