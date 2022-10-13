using MongoDB.Driver;

namespace FastDo.Net.MongoDatabase.Providers
{
    public interface IMongoDbProvider
    {
        MongoClient GetMongoClient();
        IMongoDatabase GetDatabase();
        IMongoCollection<T> GetCollection<T>();
    }
}
