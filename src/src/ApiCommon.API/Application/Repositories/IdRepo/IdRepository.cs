using ApiCommon.API.Application.Core;
using ApiCommon.Domain.Error;
using ApiCommon.MongoDatabase.Abstractions;
using ApiCommon.MongoDatabase.Providers;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace ApiCommon.API.Application.Repositories.IdRepo
{
    public class IdRepository : IIdRepository
    {
        private readonly IMongoDbProvider _mongoDbProvider;

        public IdRepository(IMongoDbProvider mongoDbProvider)
        {
            _mongoDbProvider = mongoDbProvider;
        }

        public async Task<Result<EmptyClass>> Delete<T>(string id) where T : IId
        {
            var collection = _mongoDbProvider.GetCollection<T>();

            var item = await collection.AsQueryable().FirstOrDefaultAsync(_ => _.Id == id);
            if (item is null)
                return Result<EmptyClass>.NotFound(Errors.ItemNotExists);

            await collection.DeleteOneAsync(_ => _.Id == id);

            return Result<EmptyClass>.Ok();
        }
    }
}
