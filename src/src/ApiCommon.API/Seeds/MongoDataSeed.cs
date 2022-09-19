using ApiCommon.Application.Helpers;
using ApiCommon.Domain.Enums;
using ApiCommon.MongoDatabase.Models.Users;
using ApiCommon.MongoDatabase.Providers.Interfaces;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace ApiCommon.API.Seeds
{
    public static class MongoDataSeed
    {
        public static async Task SeedData(IMongoUserCollectionsProvider mongoUserCollectionsProvider)
        {
            var superAdminUserCollection = mongoUserCollectionsProvider.GetSuperAdminUserCollection();

            if (await superAdminUserCollection.AsQueryable().CountAsync() == 0)
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

                await superAdminUserCollection.InsertOneAsync(superAdminUser);
            }
        }
    }
}
