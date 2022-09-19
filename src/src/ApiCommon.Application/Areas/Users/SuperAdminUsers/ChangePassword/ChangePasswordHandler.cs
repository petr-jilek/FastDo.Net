using ApiCommon.Application.Abstractions;
using ApiCommon.Application.Core;
using ApiCommon.Application.Helpers;
using ApiCommon.Application.Services.Interfaces.Auth;
using ApiCommon.Domain.Enums;
using ApiCommon.Domain.Error;
using ApiCommon.MongoDatabase.Providers.Interfaces;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace ApiCommon.Application.Areas.Users.SuperAdminUsers.ChangePassword
{
    public class ChangePasswordHandler : IHandler
    {
        private readonly IMongoUserCollectionsProvider _mongoUserCollectionsProvider;
        private readonly IUserAccessorService _userAccessorService;

        public ChangePasswordHandler(IMongoUserCollectionsProvider mongoUserCollectionsProvider,
            IUserAccessorService userAccessorService)
        {
            _mongoUserCollectionsProvider = mongoUserCollectionsProvider;
            _userAccessorService = userAccessorService;
        }

        public async Task<Result<EmptyClass>> Handle(ChangePasswordRequest request)
        {
            if (request.NewPassword != request.NewPasswordConfirmation)
                return Result<EmptyClass>.BadRequest(Errors.PasswordsDontMatch);

            var collection = _mongoUserCollectionsProvider.GetSuperAdminUserCollection();

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
