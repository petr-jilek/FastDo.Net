namespace ApiCommon.API.Application.Areas.General.Articles.UploadCsv
{
    public class UploadCsvItemRequest
    {
        public string? Name { get; set; }
        public DateTimeOffset? Created { get; set; }
        public DateTimeOffset? LastUpdated { get; set; }
        public string? ImageName { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }
        public int Type { get; set; }
        public int Order { get; set; }
    }
}
