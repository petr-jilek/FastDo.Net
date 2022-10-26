using FastDo.Net.MongoDatabase.Abstractions;
using FastDo.Net.MongoDatabase.Extensions;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace FastDo.Net.MongoDatabase.Extensions
{
    public static class MongoCollectionExtensions
    {
        public static async Task<ReplaceOneResult> EditOneAsync<T>(this IMongoCollection<T> collection, T item) where T : IId
            => await collection.ReplaceOneAsync(_ => _.Id == item.Id, item);
        public static async Task<DeleteResult> DeleteOneAsync<T>(this IMongoCollection<T> collection, T item) where T : IId
            => await collection.DeleteOneAsync(_ => _.Id == item.Id);

        public static async Task<DeleteResult> DeleteOneByIdAsync<T>(this IMongoCollection<T> collection, string? id) where T : IId
            => await collection.DeleteOneAsync(_ => _.Id == id);

        public static async Task<bool> ExistsByIdAsync<T>(this IMongoCollection<T> collection, string? id) where T : IId
            => await collection.AsQueryable().AnyAsync(_ => _.Id == id);

        public static async Task<T> GetSingleByIdAsync<T>(this IMongoCollection<T> collection, string? id) where T : IId
            => await collection.AsQueryable().FirstOrDefaultAsync(_ => _.Id == id);

        public static async Task<List<T>> GetAllAsync<T>(this IMongoCollection<T> collection) where T : IId
            => await collection.AsQueryable().ToListAsync();

        public static async Task<List<T>> GetPagedAsync<T>(this IMongoCollection<T> collection, int pageNumber, int pageSize) where T : IId
            => await collection
                .AsQueryable()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
    }
}
