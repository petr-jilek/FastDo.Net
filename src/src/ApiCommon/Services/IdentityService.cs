using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApiCommon.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ApiCommon.Services
{
    /// <summary>
    /// TODO
    /// </summary>
    public class IdentityService
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="configuration"></param>
        public IdentityService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="claimModels"></param>
        /// <param name="expires"></param>
        /// <returns></returns>
        public string CreateTokenAsync(List<ClaimModel> claimModels, DateTime expires)
        {
            var claims = claimModels.Select(x => new Claim(x.Type!, x.Value!));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = _configuration["JWT:Issuer"],
                Audience = _configuration["JWT:Audience"],
                Expires = expires,
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
