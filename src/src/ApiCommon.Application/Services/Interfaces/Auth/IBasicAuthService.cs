using ApiCommon.Domain.Models;

namespace ApiCommon.Application.Services.Interfaces.Auth
{
    public interface IBasicAuthService
    {
        BasicAuthCredentials? GetBasicAuthCredentials();
    }
}
