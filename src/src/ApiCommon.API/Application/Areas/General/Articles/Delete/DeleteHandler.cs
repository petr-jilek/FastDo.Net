using ApiCommon.API.Application.Abstractions;
using ApiCommon.API.Application.Core;
using ApiCommon.Domain.Error;
using ApiCommon.MongoDatabase.Models.Articles;
using ApiCommon.MongoDatabase.Providers;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace ApiCommon.API.Application.Areas.General.Articles.Delete
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
                return Result<EmptyClass>.NotFound(Errors.ArticleNotExists);

            await collection.DeleteOneAsync(_ => _.Id == id);

            return Result<EmptyClass>.Ok();
        }
    }
}
