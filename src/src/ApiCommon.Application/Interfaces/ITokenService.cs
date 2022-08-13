using System.Security.Claims;

namespace ApiCommon.Application.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(List<Claim> claims, int expiration);
    }
}
