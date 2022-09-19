using System.Security.Claims;
using ApiCommon.Application.Abstractions;
using ApiCommon.Application.Core;
using ApiCommon.Application.Helpers;
using ApiCommon.Domain.Consts;
using ApiCommon.Domain.Error;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.IdentityModel.Tokens.Jwt;
using ApiCommon.Application.Services.Interfaces.Auth;
using ApiCommon.Domain.Enums;
using ApiCommon.MongoDatabase.Providers.Interfaces;

namespace ApiCommon.Application.Areas.Users.AppUsers.Login
{
    public class LoginHandler : IHandler
    {
        private readonly IMongoUserCollectionsProvider _mongoUserCollectionsProvider;
        private readonly ITokenService _tokenService;

        public LoginHandler(IMongoUserCollectionsProvider mongoUserCollectionsProvider, ITokenService tokenService)
        {
            _mongoUserCollectionsProvider = mongoUserCollectionsProvider;
            _tokenService = tokenService;
        }

        public async Task<Result<LoginResponse>> Handle(LoginRequest request)
        {
            var collection = _mongoUserCollectionsProvider.GetAppUserCollection();

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
