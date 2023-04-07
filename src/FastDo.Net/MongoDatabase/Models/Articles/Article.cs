using FastDo.Net.MongoDatabase.Abstractions;

namespace FastDo.Net.MongoDatabase.Models.Articles
{
    public class Article : BaseDbModelStringId, IOrder
    {
        public string? Name { get; set; }
        public string? NameUrl { get; set; }
        public string? ImageName { get; set; }
        public DateTimeOffset? Created { get; set; }
        public DateTimeOffset? LastUpdated { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }
        public int Type { get; set; }
        public int Order { get; set; }
    }
}
