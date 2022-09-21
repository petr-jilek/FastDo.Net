using System.ComponentModel.DataAnnotations;
using ApiCommon.Domain.Error;

namespace ApiCommon.API.Application.Areas.General.Articles.Create
{
    public class CreateRequest
    {
        [Required(ErrorMessage = Errors.NameIsRequired)]
        [StringLength(255, ErrorMessage = Errors.NameIsTooLong)]
        public string? Name { get; set; }
        public string? ImageName { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }
        public int Type { get; set; } = 1;
    }
}
