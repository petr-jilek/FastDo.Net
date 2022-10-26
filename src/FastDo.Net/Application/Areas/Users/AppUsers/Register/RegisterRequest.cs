using System.ComponentModel.DataAnnotations;
using FastDo.Net.Domain.Errors;

namespace FastDo.Net.Application.Areas.Users.AppUsers.Register
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = FastDoErrorCodes.UserNameIsRequired)]
        [StringLength(255, ErrorMessage = FastDoErrorCodes.UserNameIsTooLong)]
        public string? UserName { get; set; }

        [Required(ErrorMessage = FastDoErrorCodes.EmailIsRequired)]
        [EmailAddress(ErrorMessage = FastDoErrorCodes.EmailIsNotValid)]
        [StringLength(255, ErrorMessage = FastDoErrorCodes.EmailIsTooLong)]
        public string? Email { get; set; }

        [Required(ErrorMessage = FastDoErrorCodes.PhoneNumberIsRequired)]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = FastDoErrorCodes.PhoneNumberIsNotValid)]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = FastDoErrorCodes.PasswordIsRequired)]
        [MinLength(6, ErrorMessage = FastDoErrorCodes.PasswordIsTooShort)]
        [StringLength(255, ErrorMessage = FastDoErrorCodes.PasswordIsTooLong)]
        public string? Password { get; set; }

        public string? PasswordConfirmation { get; set; }
    }
}
