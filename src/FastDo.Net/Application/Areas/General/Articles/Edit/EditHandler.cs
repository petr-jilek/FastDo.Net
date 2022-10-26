using FastDo.Net.Application.Abstractions;
using FastDo.Net.Application.Core;
using FastDo.Net.Domain.Errors;
using FastDo.Net.MongoDatabase.Models.Articles;
using FastDo.Net.MongoDatabase.Providers;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace FastDo.Net.Application.Areas.General.Articles.Edit
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
                return Result<EmptyClass>.NotFound(FastDoErrorCodes.ArticleNotExists);

            if (await collection.AsQueryable().AnyAsync(_ => _.Name == request.Name) && article.Name != request.Name)
                return Result<EmptyClass>.Conflict(FastDoErrorCodes.ArticleAlreadyExists);

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
