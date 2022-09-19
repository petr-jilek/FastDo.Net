using System.ComponentModel.DataAnnotations;
using ApiCommon.Domain.Error;

namespace ApiCommon.Application.Areas.Users.AppUsers.Register
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

        [Required(ErrorMessage = Errors.PasswordIsRequired)]
        [MinLength(6, ErrorMessage = Errors.PasswordIsTooShort)]
        [StringLength(255, ErrorMessage = Errors.PasswordIsTooLong)]
        public string? Password { get; set; }

        public string? PasswordConfirmation { get; set; }
    }
}
