namespace ApiCommon.API.Application.Areas.Users.AppUsers.Login
{
    public class LoginResponse
    {
        public string? Token { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Actor { get; set; }
    }
}
