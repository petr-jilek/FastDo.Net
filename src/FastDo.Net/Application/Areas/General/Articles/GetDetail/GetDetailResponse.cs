namespace FastDo.Net.Application.Areas.General.Articles.GetDetail
{
    public class GetDetailResponse
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? NameUrl { get; set; }
        public DateTimeOffset? Created { get; set; }
        public DateTimeOffset? LastUpdated { get; set; }
        public string? ImageName { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }
        public int Type { get; set; }
        public int Order { get; set; }
    }
}
