using ApiCommon.Domain.Models;

namespace ApiCommon.API.Services.Auth.BasicAuth
{
    public interface IBasicAuthService
    {
        BasicAuthCredentials? GetBasicAuthCredentials();
    }
}
