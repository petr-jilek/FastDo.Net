﻿using ApiCommon.MongoDatabase.Providers.Interfaces;
using ApiCommon.MongoDatabase.Settings;
using MongoDB.Driver;

namespace ApiCommon.MongoDatabase.Providers.Implementations
{
    public class MongoDbProvider : IMongoDbProvider
    {
        private readonly MongoDbSettings _mongoDbSettings;

        protected MongoDbProvider(MongoDbSettings mongoDbSettings)
        {
            _mongoDbSettings = mongoDbSettings;
        }

        public MongoClient GetMongoClient()
        {
            return new MongoClient(_mongoDbSettings.ConnectionString);
        }

        public IMongoDatabase GetDatabase()
        {
            var client = new MongoClient(_mongoDbSettings.ConnectionString);
            return client.GetDatabase(_mongoDbSettings.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(in string collectionName)
        {
            var client = new MongoClient(_mongoDbSettings.ConnectionString);
            var db = client.GetDatabase(_mongoDbSettings.DatabaseName);
            return db.GetCollection<T>(collectionName);
        }
    }
}
