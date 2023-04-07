using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using FastDo.Net.Api.Extensions;
using FastDo.Net.Application.Abstractions;
using FastDo.Net.Application.Core;
using FastDo.Net.Domain.Errors;
using FastDo.Net.MongoDatabase.Models.Articles;
using FastDo.Net.MongoDatabase.Providers;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace FastDo.Net.Application.Areas.General.Articles.UploadCsv
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
                return Result<EmptyClass>.BadRequest(FastDoErrorCodes.FileIsEmpty);

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
                        Result<EmptyClass>.BadRequest(FastDoErrorCodes.UndescribedError,
                            $"Špatná data: {validationResults.FirstOrDefault()}");
                });

                var articles = records.Select(_ => new Article
                {
                    Name = _.Name,
                    NameUrl = _.Name!.ToFriendlyUrl(),
                    ImageName = _.ImageName,
                    Created = _.Created,
                    LastUpdated = _.LastUpdated,
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
                        dbArticle.NameUrl = article.NameUrl;
                        dbArticle.ImageName = article.ImageName;
                        dbArticle.Created = article.Created;
                        dbArticle.LastUpdated = article.LastUpdated;
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
                return Result<EmptyClass>.BadRequest(FastDoErrorCodes.UndescribedError, $"Špatná data: {ex.Message}");
            }
        }
    }
}
