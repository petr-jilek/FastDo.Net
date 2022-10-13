namespace ApiCommon.API.Application.Areas.General.Articles.Get
{
    public class GetRequest
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int Type { get; set; } = 1;
    }
}
