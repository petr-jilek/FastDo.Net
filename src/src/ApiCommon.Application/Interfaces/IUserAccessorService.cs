namespace ApiCommon.Application.Interfaces
{
    public interface IUserAccessorService
    {
        string? GetId();
        string? GetEmail();
        string? GetUserName();
        bool IsAuthenticated();
    }
}
