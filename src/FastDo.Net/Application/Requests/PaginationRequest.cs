using System.ComponentModel.DataAnnotations;

namespace FastDo.Net.Application.Requests
{
    public class PaginationRequest
    {
        [Required]
        public int PageNumber { get; set; }

        [Required]
        public int PageSize { get; set; }
    }
}
