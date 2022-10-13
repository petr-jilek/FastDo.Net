using MongoDB.Driver;

namespace ApiCommon.MongoDatabase.Providers
{
    public interface IMongoDbProvider
    {
        MongoClient GetMongoClient();
        IMongoDatabase GetDatabase();
        IMongoCollection<T> GetCollection<T>();
    }
}
