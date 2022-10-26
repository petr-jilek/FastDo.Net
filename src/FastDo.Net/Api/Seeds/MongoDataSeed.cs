using FastDo.Net.Api.Helpers;
using FastDo.Net.Domain.Enums;
using FastDo.Net.MongoDatabase.Models.Users;
using FastDo.Net.MongoDatabase.Providers;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace FastDo.Net.Api.Seeds
{
    public static class MongoDataSeed
    {
        public static async Task SeedSuperAdmin(IMongoDbProvider mongoUserCollectionsProvider, string email, string password)
        {
            var collection = mongoUserCollectionsProvider.GetCollection<SuperAdminUser>();

            if (await collection.AsQueryable().CountAsync() == 0)
            {
                var salt = CryptographyHelper.GenerateSalt();

                var hashMethod = HashMethod.Sha512;
                var passwordHash = CryptographyHelper.CreateHash(password, salt, hashMethod);

                var superAdminUser = new SuperAdminUser()
                {
                    Email = email,
                    PasswordSalt = salt,
                    PasswordHash = passwordHash,
                    PasswordHashMethod = (int)hashMethod,
                };

                await collection.InsertOneAsync(superAdminUser);
            }
        }
    }
}
