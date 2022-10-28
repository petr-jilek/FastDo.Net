using FastDo.Net.Api.Services.Email.SendinblueEmail.Models;

namespace FastDo.Net.Api.Services.Email.SendinblueEmail
{
    public interface ISendinblueEmailService
    {
        Task<HttpResponseMessage> SendEmailAsync(Sender sender, Reciever reciever, string subject, string htmlContent);
        Task<HttpResponseMessage> SendEmailMultipleRecieversAsync(Sender sender, List<Reciever> recievers, string subject, string htmlContent);
    }
}
