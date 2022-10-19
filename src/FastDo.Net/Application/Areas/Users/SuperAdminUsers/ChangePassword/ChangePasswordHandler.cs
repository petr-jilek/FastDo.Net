using FastDo.Net.Api.Helpers;
using FastDo.Net.Api.Services.Auth.UserAccessor;
using FastDo.Net.Application.Abstractions;
using FastDo.Net.Application.Core;
using FastDo.Net.Domain.Enums;
using FastDo.Net.Domain.Errors.Codes;
using FastDo.Net.MongoDatabase.Models.Users;
using FastDo.Net.MongoDatabase.Providers;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace FastDo.Net.Application.Areas.Users.SuperAdminUsers.ChangePassword
{
    public class ChangePasswordHandler : IHandler
    {
        private readonly IMongoDbProvider _mongoDbProvider;
        private readonly IUserAccessorService _userAccessorService;

        public ChangePasswordHandler(IMongoDbProvider mongoDbProvider, IUserAccessorService userAccessorService)
        {
            _mongoDbProvider = mongoDbProvider;
            _userAccessorService = userAccessorService;
        }

        public async Task<Result<EmptyClass>> Handle(ChangePasswordRequest request)
        {
            if (request.NewPassword != request.NewPasswordConfirmation)
                return Result<EmptyClass>.BadRequest(Errors.PasswordsDontMatch);

            var collection = _mongoDbProvider.GetCollection<SuperAdminUser>();

            var userId = _userAccessorService.GetId();

            var user = await collection.AsQueryable().FirstOrDefaultAsync(_ => _.Id == userId);
            if (user is null)
                return Result<EmptyClass>.NotFound();

            if (request.Password is null || user.PasswordHash is null || user.PasswordSalt is null ||
                request.NewPassword is null)
                return Result<EmptyClass>.Unauthorized(Errors.BadPassword);

            if (CryptographyHelper.Verify(request.Password, user.PasswordHash, user.PasswordSalt,
                    (HashMethod)user.PasswordHashMethod) == false)
                return Result<EmptyClass>.Unauthorized(Errors.BadPassword);

            var hashMethod = HashMethod.Sha512;
            var newPasswordSalt = CryptographyHelper.GenerateSalt();
            var newPasswordHash = CryptographyHelper.CreateHash(request.NewPassword, newPasswordSalt, hashMethod);

            user.PasswordSalt = newPasswordSalt;
            user.PasswordHash = newPasswordHash;
            user.PasswordHashMethod = (int)hashMethod;

            await collection.ReplaceOneAsync(_ => _.Id == userId, user);

            return Result<EmptyClass>.Ok();
        }
    }
}
