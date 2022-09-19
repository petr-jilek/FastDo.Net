using System.Security.Claims;

namespace ApiCommon.Application.Services.Interfaces.Auth
{
    public interface ITokenService
    {
        string? CreateToken(List<Claim> claims, int expiration);
        Task<bool> IsTokenValidAsync(string token);
    }
}
