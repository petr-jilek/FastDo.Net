using FastDo.Net.Api.Extensions;
using FastDo.Net.Application.Abstractions;
using FastDo.Net.Application.Core;
using FastDo.Net.Domain.Errors;
using FastDo.Net.MongoDatabase.Extensions;
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

        public async Task<Result<EmptyClass>> Handle(string nameUrl, EditRequest request)
        {
            var collection = _mongoDbProvider.GetCollection<Article>();

            var article = await collection.AsQueryable().FirstOrDefaultAsync(_ => _.NameUrl == nameUrl);
            if (article is null)
                return Result<EmptyClass>.NotFound(FastDoErrorCodes.ArticleNotExists);

            var newNameUrl = request.Name!.ToFriendlyUrl();

            if (await collection.AsQueryable().AnyAsync(_ => (_.NameUrl == newNameUrl || _.Name == request.Name) && _.NameUrl != article.NameUrl))
                return Result<EmptyClass>.Conflict(FastDoErrorCodes.ArticleAlreadyExists);

            article.Name = request.Name;
            article.NameUrl = newNameUrl;
            article.LastUpdated = DateTimeOffset.UtcNow;
            article.ImageName = request.ImageName;
            article.Description = request.Description;
            article.Content = request.Content;

            await collection.UpdateOneAsync(article);

            return Result<EmptyClass>.Ok();
        }
    }
}
