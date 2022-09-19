using System.ComponentModel.DataAnnotations;
using ApiCommon.Domain.Error;

namespace ApiCommon.API.Application.Areas.General.Articles.Edit
{
    public class EditRequest
    {
        [Required(ErrorMessage = Errors.NameIsRequired)]
        [StringLength(255, ErrorMessage = Errors.NameIsTooLong)]
        public string? Name { get; set; }

        public DateTimeOffset? Created { get; set; }

        [Required(ErrorMessage = Errors.ImageIsRequired)]
        [StringLength(255, ErrorMessage = Errors.ImageNameIsTooLong)]
        public string? ImageName { get; set; }

        public string? Description { get; set; }
        public string? Content { get; set; }
    }
}
