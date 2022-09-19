namespace ApiCommon.Application.Services.Interfaces.Auth
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
