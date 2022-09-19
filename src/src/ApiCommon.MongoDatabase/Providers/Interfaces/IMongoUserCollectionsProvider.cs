using ApiCommon.MongoDatabase.Models.Users;
using MongoDB.Driver;

namespace ApiCommon.MongoDatabase.Providers
{
    public interface IMongoUserCollectionsProvider
    {
        public IMongoCollection<AppUser> GetAppUserCollection();
        public IMongoCollection<SuperAdminUser> GetSuperAdminUserCollection();
    }
}
