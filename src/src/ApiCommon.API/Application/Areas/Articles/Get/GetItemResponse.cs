namespace ApiCommon.API.Application.Areas.Articles.Get
{
    public class GetArticlesItemResponse
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public DateTimeOffset? Created { get; set; }
        public DateTimeOffset? LastUpdated { get; set; }
        public string? ImageName { get; set; }
        public string? Description { get; set; }
    }
}
