using ApiCommon.MongoDatabase.Models.Users;
using ApiCommon.MongoDatabase.Providers.Interfaces;
using ApiCommon.MongoDatabase.Settings;
using MongoDB.Driver;

namespace ApiCommon.MongoDatabase.Providers.Implementations
{
    public class MongoUserCollectionsProvider : MongoDbProvider, IMongoUserCollectionsProvider
    {
        public MongoUserCollectionsProvider(MongoDbSettings mongoDbSettings) : base(mongoDbSettings)
        {
        }

        public IMongoCollection<AppUser> GetAppUserCollection()
            => GetCollection<AppUser>(nameof(AppUser));

        public IMongoCollection<SuperAdminUser> GetSuperAdminUserCollection()
            => GetCollection<SuperAdminUser>(nameof(SuperAdminUser));
    }
}
