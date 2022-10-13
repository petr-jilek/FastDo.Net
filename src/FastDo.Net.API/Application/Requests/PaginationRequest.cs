using System.ComponentModel.DataAnnotations;

namespace ApiCommon.API.Application.Requests
{
    public class PaginationRequest
    {
        [Required]
        public int PageNumber { get; set; }

        [Required]
        public int PageSize { get; set; }
    }
}
