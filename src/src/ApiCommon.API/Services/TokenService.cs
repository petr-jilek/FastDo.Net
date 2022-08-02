using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApiCommon.Application.Interfaces;
using ApiCommon.Application.ServiceSettings;
using Microsoft.IdentityModel.Tokens;

namespace ApiCommon.API.Services
{
    public class TokenService : ITokenService
    {
        private readonly TokenServiceSettings _tokenServiceSettings;

        public TokenService(TokenServiceSettings tokenServiceSettings)
        {
            _tokenServiceSettings = tokenServiceSettings;
        }

        public string CreateToken(List<Claim> claims, int expiration)
        {

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenServiceSettings.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = _tokenServiceSettings.Issuer,
                Audience = _tokenServiceSettings.Audience,
                Expires = DateTime.UtcNow.AddMinutes(expiration),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
