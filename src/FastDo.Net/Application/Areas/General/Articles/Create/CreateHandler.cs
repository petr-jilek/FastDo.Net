using FastDo.Net.Api.Extensions;
using FastDo.Net.Application.Abstractions;
using FastDo.Net.Application.Core;
using FastDo.Net.Domain.Errors;
using FastDo.Net.MongoDatabase.Models.Articles;
using FastDo.Net.MongoDatabase.Providers;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace FastDo.Net.Application.Areas.General.Articles.Create
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

            var nameUrl = request.Name!.ToFriendlyUrl();

            if (await collection.AsQueryable().AnyAsync(_ => _.NameUrl == nameUrl || _.Name == request.Name))
                return Result<EmptyClass>.Conflict(FastDoErrorCodes.ArticleAlreadyExists);

            var maxOrder = await collection.AsQueryable().AnyAsync(_ => true)
                ? await collection.AsQueryable().MaxAsync(_ => _.Order)
                : 0;

            var article = new Article
            {
                Name = request.Name,
                NameUrl = nameUrl,
                ImageName = request.ImageName,
                Created = DateTimeOffset.UtcNow,
                LastUpdated = DateTimeOffset.UtcNow,
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
