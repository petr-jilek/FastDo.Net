namespace FastDo.Net.Application.Areas.General.Articles.Get
{
    public class GetArticlesItemResponse
    {
        public string? Name { get; set; }
        public string? NameUrl { get; set; }
        public DateTimeOffset? Created { get; set; }
        public DateTimeOffset? LastUpdated { get; set; }
        public string? ImageName { get; set; }
        public string? Description { get; set; }
    }
}
