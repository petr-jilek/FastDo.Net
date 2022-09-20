using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace ApiCommon.API.Services.Auth.Token
{
    public class TokenService : ITokenService
    {
        private readonly TokenServiceSettings _tokenServiceSettings;

        public TokenService(TokenServiceSettings tokenServiceSettings)
        {
            _tokenServiceSettings = tokenServiceSettings;
        }

        public string? CreateToken(List<Claim> claims, int expiration)
        {
            if (_tokenServiceSettings.Secret is null)
                return null;

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

        public async Task<bool> IsTokenValidAsync(string token)
        {
            if (_tokenServiceSettings.Secret is null)
                return false;

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenServiceSettings.Secret));

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,
                ValidateIssuer = true,
                ValidIssuer = _tokenServiceSettings.Issuer,
                ValidateAudience = true,
                ValidAudience = _tokenServiceSettings.Audience,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var validationResult = await tokenHandler.ValidateTokenAsync(token, tokenValidationParameters);

            return validationResult.IsValid;
        }
    }
}
