using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using ApiCommon.Domain.Responses;
using ApiCommon.Domain.Abstractions;

namespace ApiCommon.Domain.Services
{
    public class IdentityService : IApiCommonService
    {
        private readonly IConfiguration _configuration;

        public IdentityService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> CreateTokenAsync(IEnumerable<Claim> claims, int expiration = 20)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = _configuration["JWT:Issuer"],
                Audience = _configuration["JWT:Audience"],
                Expires = DateTime.UtcNow.AddMinutes(expiration),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public static async Task<LoginResponse<T>> CreateUserObjectAsync<T>(string token, T user)
            => new LoginResponse<T>()
            {
                Token = token,
                UserData = user
            };
    }
}
