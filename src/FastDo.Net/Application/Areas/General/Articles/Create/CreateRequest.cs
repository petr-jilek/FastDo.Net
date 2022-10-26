using System.ComponentModel.DataAnnotations;
using FastDo.Net.Domain.Errors;

namespace FastDo.Net.Application.Areas.General.Articles.Create
{
    public class CreateRequest
    {
        [Required(ErrorMessage = FastDoErrorCodes.NameIsRequired)]
        [StringLength(255, ErrorMessage = FastDoErrorCodes.NameIsTooLong)]
        public string? Name { get; set; }
        public string? ImageName { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }
        public int Type { get; set; } = 1;
    }
}
