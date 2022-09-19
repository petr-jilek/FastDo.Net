using MongoDB.Driver;

namespace ApiCommon.MongoDatabase.Providers.Interfaces
{
    public interface IMongoDbProvider
    {
        MongoClient GetMongoClient();
        IMongoDatabase GetDatabase();
        IMongoCollection<T> GetCollection<T>(in string collectionName);
    }
}
