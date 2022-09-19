using System.Net;
using System.Net.Mail;
using ApiCommon.Application.Services.Interfaces.Email;
using ApiCommon.Application.Services.Settings.Email;

namespace ApiCommon.API.Services.Email
{
    public class EmailSmtpService : IEmailSmtpService
    {
        private readonly EmailSmtpServiceSettings _settings;

        public EmailSmtpService(EmailSmtpServiceSettings settings)
        {
            _settings = settings;
        }

        public async Task SendEmailAsync(string email, string password, string toEmail, string subject, string body,
            bool isBodyHtml = true)
        {
            using var mail = new MailMessage();

            mail.From = new MailAddress(email);
            mail.To.Add(toEmail);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = isBodyHtml;

            using var smtp = new SmtpClient(_settings.Host, _settings.Port);

            smtp.Credentials = new NetworkCredential(email, password);
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            await smtp.SendMailAsync(mail);
        }
    }
}
