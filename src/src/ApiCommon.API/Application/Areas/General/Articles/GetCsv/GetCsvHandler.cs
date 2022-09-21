using System.Collections;
using System.Globalization;
using ApiCommon.API.Application.Abstractions;
using ApiCommon.API.Application.Core;
using ApiCommon.MongoDatabase.Models.Articles;
using ApiCommon.MongoDatabase.Providers;
using CsvHelper;
using MongoDB.Driver;

namespace ApiCommon.API.Application.Areas.General.Articles.GetCsv
{
    public class GetCsvHandler : IHandler
    {
        private readonly IMongoDbProvider _mongoDbProvider;

        public GetCsvHandler(IMongoDbProvider mongoDbProvider)
        {
            _mongoDbProvider = mongoDbProvider;
        }

        public async Task<Result<byte[]>> Handle()
        {
            var collection = _mongoDbProvider.GetCollection<Article>();

            var items = await collection.AsQueryable().ToListAsync();

            using var stream = new MemoryStream();
            await using var textWriter = new StreamWriter(stream);
            await using var csv = new CsvWriter(textWriter, CultureInfo.InvariantCulture);

            await csv.WriteRecordsAsync((IEnumerable)items);
            await textWriter.FlushAsync();
            var data = stream.ToArray();

            return Result<byte[]>.Ok(data);
        }
    }
}
