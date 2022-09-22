using System.Security.Claims;

namespace ApiCommon.API.Services.Auth.Token
{
    public interface ITokenService
    {
        string? CreateToken(List<Claim> claims, int expiration);
        Task<bool> IsTokenValidAsync(string token);
    }
}
