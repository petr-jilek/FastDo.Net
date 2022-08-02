using ApiCommon.Application.Models;

namespace ApiCommon.Application.Interfaces
{
    public interface IBasicAuthService
    {
        BasicAuthCredentials? GetBasicAuthCredentials();
    }
}
