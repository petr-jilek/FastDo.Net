using ApiCommon.MongoDatabase.Abstractions;

namespace ApiCommon.MongoDatabase.Models.Articles
{
    public class Article : BaseDbModelStringId
    {
        public string? Name { get; set; }
        public DateTimeOffset? Created { get; set; }
        public string? ImageName { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }
    }
}
