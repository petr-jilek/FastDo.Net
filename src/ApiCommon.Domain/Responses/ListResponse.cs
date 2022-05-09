using Microsoft.EntityFrameworkCore;

namespace ApiCommon.Domain.Responses
{
    public class ListResponse<T>
    {
        public List<T> Items { get; set; } = new List<T>();

        public ListResponse(IEnumerable<T> items)
        {
            Items.AddRange(items);
        }

        public static async Task<ListResponse<T>> CreateAsync(IQueryable<T> source)
        {
            var items = await source.ToListAsync();
            return new ListResponse<T>(items);
        }
    }
}
