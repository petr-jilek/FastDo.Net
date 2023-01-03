using FastDo.Net.Application.Abstractions;
using FastDo.Net.Application.Core;
using FastDo.Net.Domain.Errors;
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

        public async Task<Result<GetDetailResponse>> Handle(string nameUrl)
        {
            var collection = _mongoDbProvider.GetCollection<Article>();

            var article = await collection.AsQueryable().FirstOrDefaultAsync(_ => _.NameUrl == nameUrl);

            if (article is null)
                return Result<GetDetailResponse>.NotFound(FastDoErrorCodes.ArticleNotExists);

            var response = new GetDetailResponse()
            {
                Name = article.Name,
                NameUrl = article.NameUrl,
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
