using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using ApiCommon.API.Application.Abstractions;
using ApiCommon.API.Application.Core;
using ApiCommon.Domain.Error;
using ApiCommon.MongoDatabase.Models.Articles;
using ApiCommon.MongoDatabase.Providers;
using CsvHelper;
using CsvHelper.Configuration;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace ApiCommon.API.Application.Areas.General.Articles.UploadCsv
{
    public class UploadCsvHandler : IHandler
    {
        private readonly IMongoDbProvider _mongoDbProvider;

        public UploadCsvHandler(IMongoDbProvider mongoDbProvider)
        {
            _mongoDbProvider = mongoDbProvider;
        }

        public async Task<Result<EmptyClass>> Handle(IFormFile file)
        {
            if (file.Length == 0)
                return Result<EmptyClass>.BadRequest(Errors.FileIsEmpty);

            var config = new CsvConfiguration(CultureInfo.InvariantCulture);

            using var reader = new StreamReader(file.OpenReadStream(), Encoding.UTF8);
            using var csv = new CsvReader(reader, config);

            try
            {
                var records = csv.GetRecords<UploadCsvItemRequest>().ToList();

                records.ForEach(_ =>
                {
                    var validationContext = new ValidationContext(_, serviceProvider: null, items: null);
                    var validationResults = new List<ValidationResult>();
                    var isValid = Validator.TryValidateObject(_, validationContext, validationResults, true);

                    if (isValid == false)
                        Result<EmptyClass>.BadRequest(Errors.UndescribedError,
                            $"Špatná data: {validationResults.FirstOrDefault()}");
                });

                var articles = records.Select(_ => new Article
                {
                    Name = _.Name,
                    Created = _.Created,
                    LastUpdated = _.LastUpdated,
                    ImageName = _.ImageName,
                    Description = _.Description,
                    Content = _.Content,
                    Type = _.Type,
                    Order = _.Order,
                });

                var collection = _mongoDbProvider.GetCollection<Article>();

                foreach (var article in articles)
                {
                    var dbArticle = await collection.AsQueryable().FirstOrDefaultAsync(_ => _.Name == article.Name);

                    if (dbArticle is not null)
                    {
                        dbArticle.Name = article.Name;
                        dbArticle.Created = article.Created;
                        dbArticle.LastUpdated = article.LastUpdated;
                        dbArticle.ImageName = article.ImageName;
                        dbArticle.Description = article.Description;
                        dbArticle.Content = article.Content;
                        dbArticle.Type = article.Type;
                        dbArticle.Order = article.Order;

                        await collection.ReplaceOneAsync(_ => _.Id == dbArticle.Id, dbArticle);
                    }
                    else
                    {
                        await collection.InsertOneAsync(article);
                    }
                }

                return Result<EmptyClass>.Ok();
            }
            catch (Exception ex)
            {
                return Result<EmptyClass>.BadRequest(Errors.UndescribedError, $"Špatná data: {ex.Message}");
            }
        }
    }
}
