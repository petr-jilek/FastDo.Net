using FastDo.Net.Application.Core;
using FastDo.Net.MongoDatabase.Providers;
using MongoDB.Driver;

namespace FastDo.Net.Application.Repositories.CommonRepo
{
    public class CommonRepository : ICommonRepository
    {
        private readonly IMongoDbProvider _mongoDbProvider;

        public CommonRepository(IMongoDbProvider mongoDbProvider)
        {
            _mongoDbProvider = mongoDbProvider;
        }

        public async Task<Result<EmptyClass>> DeleteAll<T>()
        {
            var collection = _mongoDbProvider.GetCollection<T>();

            await collection.DeleteManyAsync(_ => true);

            return Result<EmptyClass>.Ok();
        }
    }
}
