using ApiCommon.Domain.Models;

namespace ApiCommon.API.Services.Auth.BasicAuthService
{
    public interface IBasicAuthService
    {
        BasicAuthCredentials? GetBasicAuthCredentials();
    }
}
