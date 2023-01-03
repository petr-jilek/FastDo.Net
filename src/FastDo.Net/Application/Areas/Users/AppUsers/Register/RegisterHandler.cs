using FastDo.Net.Api.Helpers;
using FastDo.Net.Application.Abstractions;
using FastDo.Net.Application.Core;
using FastDo.Net.Domain.Enums;
using FastDo.Net.Domain.Errors;
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
                return Result<EmptyClass>.BadRequest(FastDoErrorCodes.PasswordIsRequired);
            if (request.Password != request.PasswordConfirmation)
                return Result<EmptyClass>.BadRequest(FastDoErrorCodes.PasswordsDontMatch);

            var collection = _mongoDbProvider.GetCollection<AppUser>();

            if (await collection.AsQueryable().AnyAsync(_ => _.Email == request.Email))
                return Result<EmptyClass>.Conflict(FastDoErrorCodes.UserWithEmailAlreadyExists);

            var user = new AppUser
            {
                UserName = request.UserName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                PasswordCredentials = CryptographyHelper.CreatePasswordCredentialsSha256(request.Password),
            };

            await collection.InsertOneAsync(user);

            return Result<EmptyClass>.Ok();
        }
    }
}
