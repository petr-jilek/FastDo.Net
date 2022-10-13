using System.Security.Claims;

namespace FastDo.Net.Api.Services.Auth.Token
{
    public interface ITokenService
    {
        string? CreateToken(List<Claim> claims, int expiration);
        Task<bool> IsTokenValidAsync(string token);
    }
}
