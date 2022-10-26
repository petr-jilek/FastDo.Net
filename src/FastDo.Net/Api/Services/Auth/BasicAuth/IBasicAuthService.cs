using FastDo.Net.Domain.Models;

namespace FastDo.Net.Api.Services.Auth.BasicAuth
{
    public interface IBasicAuthService
    {
        BasicAuthCredentials? GetBasicAuthCredentials();
    }
}
