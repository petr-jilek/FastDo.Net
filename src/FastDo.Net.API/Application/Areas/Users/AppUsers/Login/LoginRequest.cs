using System.ComponentModel.DataAnnotations;
using FastDo.Net.Domain.Error;

namespace FastDo.Net.Api.Application.Areas.Users.AppUsers.Login
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
