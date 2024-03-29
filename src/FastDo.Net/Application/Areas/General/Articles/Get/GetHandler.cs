﻿using FastDo.Net.Application.Abstractions;
using FastDo.Net.Application.Core;
using FastDo.Net.MongoDatabase.Models.Articles;
using FastDo.Net.MongoDatabase.Providers;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace FastDo.Net.Application.Areas.General.Articles.Get
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
                .OrderByDescending(_ => _.Order)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(_ => new GetArticlesItemResponse()
                {
                    Id = _.Id,
                    Name = _.Name,
                    NameUrl = _.NameUrl,
                    Created = _.Created,
                    LastUpdated = _.LastUpdated,
                    ImageName = _.ImageName,
                    Description = _.Description,
                    Order = _.Order,
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
