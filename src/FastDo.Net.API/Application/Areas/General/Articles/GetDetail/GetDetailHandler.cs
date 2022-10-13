using FastDo.Net.Application.Abstractions;
using FastDo.Net.Application.Core;
using FastDo.Net.Domain.Error;
using FastDo.Net.MongoDatabase.Models.Articles;
using FastDo.Net.MongoDatabase.Providers;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace FastDo.Net.Application.Areas.General.Articles.GetDetail
{
    public class GetDetailHandler : IHandler
    {
        private readonly IMongoDbProvider _mongoDbProvider;

        public GetDetailHandler(IMongoDbProvider mongoDbProvider)
        {
            _mongoDbProvider = mongoDbProvider;
        }

        public async Task<Result<GetDetailResponse>> Handle(string id)
        {
            var collection = _mongoDbProvider.GetCollection<Article>();

            var article = await collection.AsQueryable().FirstOrDefaultAsync(_ => _.Id == id);

            if (article is null)
                return Result<GetDetailResponse>.NotFound(Errors.ArticleNotExists);

            var response = new GetDetailResponse()
            {
                Id = article.Id,
                Name = article.Name,
                Created = article.Created,
                LastUpdated = article.LastUpdated,
                ImageName = article.ImageName,
                Description = article.Description,
                Content = article.Content,
                Type = article.Type,
                Order = article.Order,
            };

            return Result<GetDetailResponse>.Ok(response);
        }
    }
}
