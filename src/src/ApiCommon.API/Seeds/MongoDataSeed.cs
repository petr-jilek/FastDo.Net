using ApiCommon.API.Helpers;
using ApiCommon.Domain.Enums;
using ApiCommon.MongoDatabase.Models.Users;
using ApiCommon.MongoDatabase.Providers;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace ApiCommon.API.Seeds
{
    public static class MongoDataSeed
    {
        public static async Task SeedSuperAdmin(IMongoDbProvider mongoUserCollectionsProvider)
        {
            var collection = mongoUserCollectionsProvider.GetCollection<SuperAdminUser>();

            if (await collection.AsQueryable().CountAsync() == 0)
            {
                var password = "Test123!";
                var salt = CryptographyHelper.GenerateSalt();

                var hashMethod = HashMethod.Sha512;
                var passwordHash = CryptographyHelper.CreateHash(password, salt, hashMethod);

                var superAdminUser = new SuperAdminUser()
                {
                    Email = "superadmin@superadmin.superadmin",
                    PasswordSalt = salt,
                    PasswordHash = passwordHash,
                    PasswordHashMethod = (int)hashMethod,
                };

                await collection.InsertOneAsync(superAdminUser);
            }
        }
    }
}
