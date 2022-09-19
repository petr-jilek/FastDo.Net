using ApiCommon.API.Application.Abstractions;
using ApiCommon.API.Application.Core;
using ApiCommon.Domain.Error;
using ApiCommon.MongoDatabase.Models.Articles;
using ApiCommon.MongoDatabase.Providers;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace ApiCommon.API.Application.Areas.Articles.Edit
{
    public class EditHandler : IHandler
    {
        private readonly IMongoDbProvider _mongoDbProvider;

        public EditHandler(IMongoDbProvider mongoDbProvider)
        {
            _mongoDbProvider = mongoDbProvider;
        }

        public async Task<Result<EmptyClass>> Handle(string id, EditRequest request)
        {
            var collection = _mongoDbProvider.GetCollection<Article>();

            var article = await collection.AsQueryable().FirstOrDefaultAsync(_ => _.Id == id);

            if (article is null)
                return Result<EmptyClass>.NotFound(Errors.ArticleNotExists);

            if (await collection.AsQueryable().AnyAsync(_ => _.Name == request.Name) && article.Name != request.Name)
                return Result<EmptyClass>.Conflict(Errors.ArticleAlreadyExists);

            article.Name = request.Name;
            article.Created = request.Created;
            article.ImageName = request.ImageName;
            article.Description = request.Description;
            article.Content = request.Content;

            await collection.ReplaceOneAsync(_ => _.Id == id, article);

            return Result<EmptyClass>.Ok();
        }
    }
}
