using FastDo.Net.Application.Core;
using FastDo.Net.Domain.Errors;
using FastDo.Net.MongoDatabase.Abstractions;
using FastDo.Net.MongoDatabase.Providers;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace FastDo.Net.Application.Repositories.OrderRepo
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IMongoDbProvider _mongoDbProvider;

        public OrderRepository(IMongoDbProvider mongoDbProvider)
        {
            _mongoDbProvider = mongoDbProvider;
        }

        public async Task<Result<EmptyClass>> Lower<T>(string id) where T : IId, IOrder
        {
            var collection = _mongoDbProvider.GetCollection<T>();

            var item = await collection.AsQueryable().FirstOrDefaultAsync(_ => _.Id == id);
            if (item is null)
                return Result<EmptyClass>.NotFound(FastDoErrorCodes.ItemNotExists);

            var itemWithLowerOrder = await collection
                .AsQueryable()
                .Where(_ => _.Order < item.Order)
                .OrderByDescending(_ => _.Order)
                .FirstOrDefaultAsync();
            if (itemWithLowerOrder is null)
                return Result<EmptyClass>.Ok();

            (itemWithLowerOrder.Order, item.Order) = (item.Order, itemWithLowerOrder.Order);

            await collection.ReplaceOneAsync(_ => _.Id == item.Id, item);
            await collection.ReplaceOneAsync(_ => _.Id == itemWithLowerOrder.Id, itemWithLowerOrder);

            return Result<EmptyClass>.Ok();
        }

        public async Task<Result<EmptyClass>> Higher<T>(string id) where T : IId, IOrder
        {
            var collection = _mongoDbProvider.GetCollection<T>();

            var item = await collection.AsQueryable().FirstOrDefaultAsync(_ => _.Id == id);
            if (item is null)
                return Result<EmptyClass>.NotFound(FastDoErrorCodes.ItemNotExists);

            var itemWithHigherOrder = await collection
                .AsQueryable()
                .Where(_ => _.Order > item.Order)
                .OrderBy(_ => _.Order)
                .FirstOrDefaultAsync();
            if (itemWithHigherOrder is null)
                return Result<EmptyClass>.Ok();

            (itemWithHigherOrder.Order, item.Order) = (item.Order, itemWithHigherOrder.Order);

            await collection.ReplaceOneAsync(_ => _.Id == item.Id, item);
            await collection.ReplaceOneAsync(_ => _.Id == itemWithHigherOrder.Id, itemWithHigherOrder);

            return Result<EmptyClass>.Ok();
        }
    }
}
