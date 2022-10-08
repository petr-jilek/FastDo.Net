namespace ApiCommon.API.Application.Responses
{
    public class PaginationResponse<T>
    {
        public List<T>? Items { get; set; }
        public int TotalCount { get; set; }
    }
}
