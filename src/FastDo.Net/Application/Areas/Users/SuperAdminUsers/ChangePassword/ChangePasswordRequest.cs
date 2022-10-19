using System.ComponentModel.DataAnnotations;
using FastDo.Net.Domain.Errors.Codes;

namespace FastDo.Net.Application.Areas.Users.SuperAdminUsers.ChangePassword
{
    public class ChangePasswordRequest
    {
        [Required(ErrorMessage = Errors.PasswordIsRequired)]
        [StringLength(255, ErrorMessage = Errors.PasswordIsTooLong)]
        public string? Password { get; set; }

        [Required(ErrorMessage = Errors.NewPasswordIsRequired)]
        [MinLength(6, ErrorMessage = Errors.NewPasswordIsTooShort)]
        [StringLength(255, ErrorMessage = Errors.NewPasswordIsTooLong)]
        public string? NewPassword { get; set; }

        public string? NewPasswordConfirmation { get; set; }
    }
}
