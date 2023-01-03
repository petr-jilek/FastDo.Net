using FastDo.Net.Api.Helpers;
using FastDo.Net.Api.Services.Auth.UserAccessor;
using FastDo.Net.Application.Abstractions;
using FastDo.Net.Application.Core;
using FastDo.Net.Domain.Errors;
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
                return Result<EmptyClass>.BadRequest(FastDoErrorCodes.PasswordsDontMatch);

            var collection = _mongoDbProvider.GetCollection<SuperAdminUser>();

            var userId = _userAccessorService.GetId();

            var user = await collection.AsQueryable().FirstOrDefaultAsync(_ => _.Id == userId);
            if (user is null)
                return Result<EmptyClass>.NotFound();

            if (CryptographyHelper.Verify(request.Password!, user.PasswordCredentials!) == false)
                return Result<EmptyClass>.Unauthorized(FastDoErrorCodes.BadPassword);

            user.PasswordCredentials = CryptographyHelper.CreatePasswordCredentialsSha256(request.NewPassword!);

            await collection.ReplaceOneAsync(_ => _.Id == userId, user);

            return Result<EmptyClass>.Ok();
        }
    }
}
