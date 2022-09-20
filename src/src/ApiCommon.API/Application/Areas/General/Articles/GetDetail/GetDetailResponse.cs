namespace ApiCommon.API.Application.Areas.General.Articles.GetDetail
{
    public class GetDetailResponse
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public DateTimeOffset? Created { get; set; }
        public string? ImageName { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }
    }
}
