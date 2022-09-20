using ApiCommon.API.Application.Abstractions;
using ApiCommon.API.Application.Core;
using ApiCommon.MongoDatabase.Models.Articles;
using ApiCommon.MongoDatabase.Providers;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace ApiCommon.API.Application.Areas.General.Articles.Get
{
    public class GetHandler : IHandler
    {
        private readonly IMongoDbProvider _mongoDbProvider;

        public GetHandler(IMongoDbProvider mongoDbProvider)
        {
            _mongoDbProvider = mongoDbProvider;
        }

        public async Task<Result<GetResponse>> Handle(GetRequest request)
        {
            var collection = _mongoDbProvider.GetCollection<Article>();
            
            var articles = await collection
                .AsQueryable()
                .OrderByDescending(_ => _.Created)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(_ => new GetArticlesItemResponse()
                {
                    Id = _.Id,
                    Name = _.Name,
                    Created = _.Created,
                    ImageName = _.ImageName,
                    Description = _.Description,
                })
                .ToListAsync();


            var response = new GetResponse()
            {
                Items = articles,
                TotalCount = await collection.AsQueryable().CountAsync(),
            };

            return Result<GetResponse>.Ok(response);
        }
    }
}
