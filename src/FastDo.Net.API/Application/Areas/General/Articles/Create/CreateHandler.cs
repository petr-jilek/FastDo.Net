using ApiCommon.API.Application.Abstractions;
using ApiCommon.API.Application.Core;
using ApiCommon.Domain.Error;
using ApiCommon.MongoDatabase.Models.Articles;
using ApiCommon.MongoDatabase.Providers;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace ApiCommon.API.Application.Areas.General.Articles.Create
{
    public class CreateHandler : IHandler
    {
        private readonly IMongoDbProvider _mongoDbProvider;

        public CreateHandler(IMongoDbProvider mongoDbProvider)
        {
            _mongoDbProvider = mongoDbProvider;
        }

        public async Task<Result<EmptyClass>> Handle(CreateRequest request)
        {
            var collection = _mongoDbProvider.GetCollection<Article>();
            if (await collection.AsQueryable().AnyAsync(_ => _.Name == request.Name))
                return Result<EmptyClass>.Conflict(Errors.ArticleAlreadyExists);

            var maxOrder = await collection.AsQueryable().AnyAsync(_ => true)
                ? await collection.AsQueryable().MaxAsync(_ => _.Order)
                : 0;

            var article = new Article
            {
                Name = request.Name,
                Created = DateTimeOffset.UtcNow,
                LastUpdated = DateTimeOffset.UtcNow,
                ImageName = request.ImageName,
                Description = request.Description,
                Content = request.Content,
                Type = request.Type,
                Order = maxOrder + 1,
            };

            await collection.InsertOneAsync(article);

            return Result<EmptyClass>.Ok();
        }
    }
}
