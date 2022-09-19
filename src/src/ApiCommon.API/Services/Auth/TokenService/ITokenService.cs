using System.Security.Claims;

namespace ApiCommon.API.Services.Auth.TokenService
{
    public interface ITokenService
    {
        string? CreateToken(List<Claim> claims, int expiration);
        Task<bool> IsTokenValidAsync(string token);
    }
}
