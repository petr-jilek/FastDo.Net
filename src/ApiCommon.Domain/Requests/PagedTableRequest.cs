namespace ApiCommon.Domain.Requests
{
    public class PagedTableRequest<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Search { get; set; }
        public T? Filter { get; set; }
    }
}
