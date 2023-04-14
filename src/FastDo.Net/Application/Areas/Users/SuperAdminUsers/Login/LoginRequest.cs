using System.ComponentModel.DataAnnotations;
using FastDo.Net.Domain.Errors;

namespace FastDo.Net.Application.Areas.Users.SuperadminUsers.Login
{
    public class LoginRequest
    {
        [Required(ErrorMessage = FastDoErrorCodes.EmailIsRequired)]
        [EmailAddress(ErrorMessage = FastDoErrorCodes.EmailIsNotValid)]
        [StringLength(255, ErrorMessage = FastDoErrorCodes.EmailIsTooLong)]
        public string? Email { get; set; }

        [Required(ErrorMessage = FastDoErrorCodes.PasswordIsRequired)]
        [StringLength(255, ErrorMessage = FastDoErrorCodes.PasswordIsTooLong)]
        public string? Password { get; set; }
    }
}
