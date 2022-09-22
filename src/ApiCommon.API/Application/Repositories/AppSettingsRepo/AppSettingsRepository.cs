using ApiCommon.MongoDatabase.Models.Settings;
using ApiCommon.MongoDatabase.Providers;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace ApiCommon.API.Application.Repositories.AppSettingsRepo
{
    public class AppSettingsRepository : IAppSettingsRepository
    {
        private readonly IMongoDbProvider _mongoDbProvider;

        public AppSettingsRepository(IMongoDbProvider mongoDbProvider)
        {
            _mongoDbProvider = mongoDbProvider;
        }

        public async Task AddItemAsync<T>(string key, T value)
        {
            if (string.IsNullOrWhiteSpace(key))
                return;

            var collection = _mongoDbProvider.GetCollection<AppSettings>();

            var item = await collection.AsQueryable().FirstOrDefaultAsync(_ => _.Key == key);
            if (item is not null)
                await collection.DeleteOneAsync(_ => _.Key == key);

            var newItem = new AppSettings() { Key = key, Value = value };
            await collection.InsertOneAsync(newItem);
        }

        public async Task<T?> GetItemAsync<T>(string key)
        {
            var collection = _mongoDbProvider.GetCollection<AppSettings>();

            var item = await collection.AsQueryable().FirstOrDefaultAsync(_ => _.Key == key);
            if (item is null)
                return default(T);

            if (item.Value is T value)
                return value;

            try
            {
                return (T)Convert.ChangeType(item.Value, typeof(T))!;
            }
            catch (InvalidCastException)
            {
                return default(T);
            }
        }

        public async Task<List<AppSettings>> GetAllAsync()
        {
            var collection = _mongoDbProvider.GetCollection<AppSettings>();

            return await collection.AsQueryable().ToListAsync();
        }

        public async Task<List<string?>> GetAllKeysAsync()
        {
            var collection = _mongoDbProvider.GetCollection<AppSettings>();

            return await collection
                .AsQueryable()
                .Select(_ => _.Key)
                .ToListAsync();
        }

        public async Task RemoveItem(string key)
        {
            var collection = _mongoDbProvider.GetCollection<AppSettings>();
            await collection.DeleteOneAsync(_ => _.Key == key);
        }
    }
}
