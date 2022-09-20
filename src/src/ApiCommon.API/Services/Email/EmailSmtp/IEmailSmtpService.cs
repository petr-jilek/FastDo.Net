namespace ApiCommon.API.Services.Email.EmailSmtp
{
    public interface IEmailSmtpService
    {
        Task SendEmailAsync(string email, string password, string toEmail, string subject, string body, bool isBodyHtml = true);
    }
}
