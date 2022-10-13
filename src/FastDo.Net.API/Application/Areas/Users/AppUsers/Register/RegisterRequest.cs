using System.ComponentModel.DataAnnotations;
using FastDo.Net.Domain.Error;

namespace FastDo.Net.Api.Application.Areas.Users.AppUsers.Register
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = Errors.UserNameIsRequired)]
        [StringLength(255, ErrorMessage = Errors.UserNameIsTooLong)]
        public string? UserName { get; set; }

        [Required(ErrorMessage = Errors.EmailIsRequired)]
        [EmailAddress(ErrorMessage = Errors.EmailIsNotValid)]
        [StringLength(255, ErrorMessage = Errors.EmailIsTooLong)]
        public string? Email { get; set; }

        [Required(ErrorMessage = Errors.PhoneNumberIsRequired)]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = Errors.PhoneNumberIsNotValid)]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = Errors.PasswordIsRequired)]
        [MinLength(6, ErrorMessage = Errors.PasswordIsTooShort)]
        [StringLength(255, ErrorMessage = Errors.PasswordIsTooLong)]
        public string? Password { get; set; }

        public string? PasswordConfirmation { get; set; }
    }
}
