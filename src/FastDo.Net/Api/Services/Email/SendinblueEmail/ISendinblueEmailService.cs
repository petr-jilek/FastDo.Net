using FastDo.Net.Api.Services.Email.SendinblueEmail.Models;

namespace FastDo.Net.Api.Services.Email.SendinblueEmail
{
    public interface ISendinblueEmailService
    {
        Task<HttpResponseMessage> SendEmailAsync(EmailUser sender, EmailUser reciever, string subject, string htmlContent);
        Task<HttpResponseMessage> SendEmailMultipleRecieversAsync(EmailUser sender, List<EmailUser> recievers, string subject, string htmlContent);
    }
}
