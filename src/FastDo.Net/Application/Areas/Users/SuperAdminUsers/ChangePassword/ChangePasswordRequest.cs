using System.ComponentModel.DataAnnotations;
using FastDo.Net.Domain.Errors;

namespace FastDo.Net.Application.Areas.Users.SuperadminUsers.ChangePassword
{
    public class ChangePasswordRequest
    {
        [Required(ErrorMessage = FastDoErrorCodes.PasswordIsRequired)]
        [StringLength(255, ErrorMessage = FastDoErrorCodes.PasswordIsTooLong)]
        public string? Password { get; set; }

        [Required(ErrorMessage = FastDoErrorCodes.NewPasswordIsRequired)]
        [MinLength(6, ErrorMessage = FastDoErrorCodes.NewPasswordIsTooShort)]
        [StringLength(255, ErrorMessage = FastDoErrorCodes.NewPasswordIsTooLong)]
        public string? NewPassword { get; set; }

        public string? NewPasswordConfirmation { get; set; }
    }
}
