using FastDo.Net.Api.Application.Abstractions;
using FastDo.Net.Api.Application.Core;
using FastDo.Net.Domain.Error;
using FastDo.Net.MongoDatabase.Models.Articles;
using FastDo.Net.MongoDatabase.Providers;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace FastDo.Net.Api.Application.Areas.General.Articles.Edit
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
            article.LastUpdated = DateTimeOffset.UtcNow;
            article.ImageName = request.ImageName;
            article.Description = request.Description;
            article.Content = request.Content;

            await collection.ReplaceOneAsync(_ => _.Id == id, article);

            return Result<EmptyClass>.Ok();
        }
    }
}
