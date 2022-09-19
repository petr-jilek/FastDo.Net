using ApiCommon.Application.Abstractions;
using ApiCommon.Application.Core;
using ApiCommon.Application.Helpers;
using ApiCommon.Domain.Enums;
using ApiCommon.Domain.Error;
using ApiCommon.MongoDatabase.Models.Users;
using ApiCommon.MongoDatabase.Providers;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace ApiCommon.Application.Areas.Users.AppUsers.Register
{
    public class RegisterHandler : IHandler
    {
        private readonly IMongoUserCollectionsProvider _mongoUserCollectionsProvider;

        public RegisterHandler(IMongoUserCollectionsProvider mongoUserCollectionsProvider)
        {
            _mongoUserCollectionsProvider = mongoUserCollectionsProvider;
        }

        public async Task<Result<EmptyClass>> Handle(RegisterRequest request)
        {
            if (request.Password != request.PasswordConfirmation)
                return Result<EmptyClass>.BadRequest(Errors.PasswordsDontMatch);
   
            var collection = _mongoUserCollectionsProvider.GetAppUserCollection();

            if (await collection.AsQueryable().AnyAsync(_ => _.Email == request.Email))
                return Result<EmptyClass>.Conflict(Errors.UserWithEmailAlreadyExists);

            var salt = CryptographyHelper.GenerateSalt();

            var hashMethod = HashMethod.Sha512;
            var hash = CryptographyHelper.CreateHash(request.Password!, salt, hashMethod);

            var user = new AppUser
            {
                UserName = request.UserName!,
                Email = request.Email!,

                PasswordSalt = salt,
                PasswordHash = hash,
                PasswordHashMethod = (int)hashMethod,
            };

            await collection.InsertOneAsync(user);

            return Result<EmptyClass>.Ok();
        }
    }
}
