using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ApiCommon.API.Application.Abstractions;
using ApiCommon.API.Application.Core;
using ApiCommon.API.Helpers;
using ApiCommon.API.Services.Auth.TokenService;
using ApiCommon.Domain.Consts;
using ApiCommon.Domain.Enums;
using ApiCommon.Domain.Error;
using ApiCommon.MongoDatabase.Models.Users;
using ApiCommon.MongoDatabase.Providers;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace ApiCommon.API.Application.Areas.Users.AppUsers.Login
{
    public class LoginHandler : IHandler
    {
        private readonly IMongoDbProvider _mongoDbProvider;
        private readonly ITokenService _tokenService;
        
        public LoginHandler(IMongoDbProvider mongoDbProvider, ITokenService tokenService)
        {
            _mongoDbProvider = mongoDbProvider;
            _tokenService = tokenService;
        }

        public async Task<Result<LoginResponse>> Handle(LoginRequest request)
        {
            var collection = _mongoDbProvider.GetCollection<AppUser>();

            var user = await collection.AsQueryable().FirstOrDefaultAsync(_ => _.Email == request.Email);
            if (user is null)
                return Result<LoginResponse>.BadRequest(Errors.BadEmailOrPassword);

            if (request.Password is null || user.PasswordHash is null || user.PasswordSalt is null)
                return Result<LoginResponse>.BadRequest(Errors.BadEmailOrPassword);

            if (CryptographyHelper.Verify(request.Password, user.PasswordHash, user.PasswordSalt,
                    (HashMethod)user.PasswordHashMethod) == false)
                return Result<LoginResponse>.BadRequest(Errors.BadEmailOrPassword);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id!), new Claim(ClaimTypes.Actor, UserActors.AppUser),
            };

            var response = new LoginResponse()
            {
                Token = _tokenService.CreateToken(claims, 20),
                UserName = user.UserName,
                Email = user.Email,
                Actor = UserActors.AppUser,
            };

            return Result<LoginResponse>.Ok(response);
        }
    }
}
