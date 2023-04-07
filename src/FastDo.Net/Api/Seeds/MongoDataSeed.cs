using FastDo.Net.Api.Helpers;
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
            var collection = mongoUserCollectionsProvider.GetCollection<SuperadminUser>();

            if (await collection.AsQueryable().CountAsync() == 0)
            {                
                var superAdminUser = new SuperadminUser()
                {
                    Email = email,
                    PasswordCredentials = CryptographyHelper.CreatePasswordCredentialsSha256(password),
                };

                await collection.InsertOneAsync(superAdminUser);
            }
        }
    }
}
