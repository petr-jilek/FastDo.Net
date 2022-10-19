using System.ComponentModel.DataAnnotations;
using FastDo.Net.Domain.Errors.Codes;

namespace FastDo.Net.Application.Areas.General.Articles.Edit
{
    public class EditRequest
    {
        [Required(ErrorMessage = Errors.NameIsRequired)]
        [StringLength(255, ErrorMessage = Errors.NameIsTooLong)]
        public string? Name { get; set; }
        public string? ImageName { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }
    }
}
