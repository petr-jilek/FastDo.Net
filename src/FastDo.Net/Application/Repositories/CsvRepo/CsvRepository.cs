using System.Globalization;
using CsvHelper;
using FastDo.Net.Application.Core;
using FastDo.Net.MongoDatabase.Providers;
using MongoDB.Driver;

namespace FastDo.Net.Application.Repositories.CsvRepo
{
    public class CsvRepository : ICsvRepository
    {
        private readonly IMongoDbProvider _mongoDbProvider;

        public CsvRepository(IMongoDbProvider mongoDbProvider)
        {
            _mongoDbProvider = mongoDbProvider;
        }

        public async Task<Result<byte[]>> GetCsvAllItems<T>()
        {
            var collection = _mongoDbProvider.GetCollection<T>();

            var items = await collection.AsQueryable().ToListAsync();

            using var stream = new MemoryStream();
            await using var textWriter = new StreamWriter(stream);
            await using var csv = new CsvWriter(textWriter, CultureInfo.InvariantCulture);

            await csv.WriteRecordsAsync(items);
            await textWriter.FlushAsync();
            var data = stream.ToArray();

            return Result<byte[]>.Ok(data);
        }
    }
}
