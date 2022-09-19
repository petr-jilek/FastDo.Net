namespace ApiCommon.API.Services.Auth.UserAccessorService
{
    public interface IUserAccessorService
    {
        string? GetId();
        string? GetEmail();
        string? GetUserName();
        bool IsAuthenticated();
        string? GetToken();
    }
}
