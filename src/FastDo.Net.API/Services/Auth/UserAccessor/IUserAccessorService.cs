namespace FastDo.Net.Api.Services.Auth.UserAccessor
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
