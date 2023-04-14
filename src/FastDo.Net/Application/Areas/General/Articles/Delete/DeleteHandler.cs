using FastDo.Net.Application.Abstractions;
using FastDo.Net.Application.Core;
using FastDo.Net.Domain.Errors;
using FastDo.Net.MongoDatabase.Extensions;
using FastDo.Net.MongoDatabase.Models.Articles;
using FastDo.Net.MongoDatabase.Providers;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace FastDo.Net.Application.Areas.General.Articles.Delete
{
    public class DeleteHandler : IHandler
    {
        private readonly IMongoDbProvider _mongoDbProvider;

        public DeleteHandler(IMongoDbProvider mongoDbProvider)
        {
            _mongoDbProvider = mongoDbProvider;
        }

        public async Task<Result<EmptyClass>> Handle(string id)
        {
            var collection = _mongoDbProvider.GetCollection<Article>();

            var article = await collection.AsQueryable().FirstOrDefaultAsync(_ => _.Id == id);
            if (article is null)
                return Result<EmptyClass>.NotFound(FastDoErrorCodes.ArticleNotExists);

            await collection.DeleteOneAsync(article);

            return Result<EmptyClass>.Ok();
        }
    }
}
