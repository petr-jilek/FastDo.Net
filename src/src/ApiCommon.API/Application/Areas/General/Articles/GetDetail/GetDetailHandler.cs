using ApiCommon.API.Application.Abstractions;
using ApiCommon.API.Application.Core;
using ApiCommon.Domain.Error;
using ApiCommon.MongoDatabase.Models.Articles;
using ApiCommon.MongoDatabase.Providers;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace ApiCommon.API.Application.Areas.General.Articles.GetDetail
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
                ImageName = article.ImageName,
                Description = article.Description,
                Content = article.Content,
            };

            return Result<GetDetailResponse>.Ok(response);
        }
    }
}
