﻿using ApiCommon.API.Application.Abstractions;
using ApiCommon.API.Application.Core;
using ApiCommon.Domain.Error;
using ApiCommon.MongoDatabase.Models.Articles;
using ApiCommon.MongoDatabase.Providers;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace ApiCommon.API.Application.Areas.Articles.Create
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

            var article = new Article
            {
                Name = request.Name,
                Created = request.Created,
                ImageName = request.ImageName,
                Description = request.Description,
                Content = request.Content,
            };

            await collection.InsertOneAsync(article);

            return Result<EmptyClass>.Ok();
        }
    }
}