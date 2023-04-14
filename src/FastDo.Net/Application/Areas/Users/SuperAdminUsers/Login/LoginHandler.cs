using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using FastDo.Net.Api.Helpers;
using FastDo.Net.Api.Services.Auth.Token;
using FastDo.Net.Application.Abstractions;
using FastDo.Net.Application.Core;
using FastDo.Net.Domain.Consts;
using FastDo.Net.Domain.Errors;
using FastDo.Net.MongoDatabase.Models.Users;
using FastDo.Net.MongoDatabase.Providers;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace FastDo.Net.Application.Areas.Users.SuperadminUsers.Login
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
            var collection = _mongoDbProvider.GetCollection<SuperadminUser>();

            var user = await collection.AsQueryable().FirstOrDefaultAsync(_ => _.Email == request.Email);
            if (user is null)
                return Result<LoginResponse>.BadRequest(FastDoErrorCodes.BadEmailOrPassword);

            if (CryptographyHelper.Verify(request.Password!, user.PasswordCredentials!) == false)
                return Result<LoginResponse>.BadRequest(FastDoErrorCodes.BadEmailOrPassword);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id!),
                new Claim(System.Security.Claims.ClaimTypes.Actor, UserActors.SuperAdmin),
            };

            var response = new LoginResponse()
            {
                Token = _tokenService.CreateToken(claims, 500),
                Actor = UserActors.SuperAdmin,
            };

            return Result<LoginResponse>.Ok(response);
        }
    }
}
