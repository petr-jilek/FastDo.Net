using ApiCommon.MongoDatabase.Models.Settings;

namespace ApiCommon.API.Application.Repositories.AppSettingsRepo
{
    public interface IAppSettingsRepository
    {
        Task AddItemAsync<T>(string key, T value);
        Task<T?> GetItemAsync<T>(string key);
        Task<List<AppSettings>> GetAllAsync(); 
        Task<List<string?>> GetAllKeysAsync();
        Task RemoveItem(string key);
    }
}
