using System.ComponentModel.DataAnnotations;
using ApiCommon.Domain.Error;

namespace ApiCommon.Application.Areas.Users.SuperAdminUsers.Login
{
    public class LoginRequest
    {
        [Required(ErrorMessage = Errors.EmailIsRequired)]
        [EmailAddress(ErrorMessage = Errors.EmailIsNotValid)]
        [StringLength(255, ErrorMessage = Errors.EmailIsTooLong)]
        public string? Email { get; set; }

        [Required(ErrorMessage = Errors.PasswordIsRequired)]
        [StringLength(255, ErrorMessage = Errors.PasswordIsTooLong)]
        public string? Password { get; set; }
    }
}
