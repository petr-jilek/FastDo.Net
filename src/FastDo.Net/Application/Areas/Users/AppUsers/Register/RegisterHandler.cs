using FastDo.Net.Api.Helpers;
using FastDo.Net.Application.Abstractions;
using FastDo.Net.Application.Core;
using FastDo.Net.Domain.Enums;
using FastDo.Net.Domain.Errors.Codes;
using FastDo.Net.MongoDatabase.Models.Users;
using FastDo.Net.MongoDatabase.Providers;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace FastDo.Net.Application.Areas.Users.AppUsers.Register
{
    public class RegisterHandler : IHandler
    {
        private readonly IMongoDbProvider _mongoDbProvider;

        public RegisterHandler(IMongoDbProvider mongoDbProvider)
        {
            _mongoDbProvider = mongoDbProvider;
        }

        public async Task<Result<EmptyClass>> Handle(RegisterRequest request)
        {
            if (request.Password is null)
                return Result<EmptyClass>.BadRequest(Errors.PasswordIsRequired);
            if (request.Password != request.PasswordConfirmation)
                return Result<EmptyClass>.BadRequest(Errors.PasswordsDontMatch);

            var collection = _mongoDbProvider.GetCollection<AppUser>();

            if (await collection.AsQueryable().AnyAsync(_ => _.Email == request.Email))
                return Result<EmptyClass>.Conflict(Errors.UserWithEmailAlreadyExists);

            var salt = CryptographyHelper.GenerateSalt();

            var hashMethod = HashMethod.Sha512;
            var hash = CryptographyHelper.CreateHash(request.Password, salt, hashMethod);

            var user = new AppUser
            {
                UserName = request.UserName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                PasswordSalt = salt,
                PasswordHash = hash,
                PasswordHashMethod = (int)hashMethod,
            };

            await collection.InsertOneAsync(user);

            return Result<EmptyClass>.Ok();
        }
    }
}
