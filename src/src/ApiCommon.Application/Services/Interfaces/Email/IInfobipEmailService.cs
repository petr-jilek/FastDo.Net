namespace ApiCommon.Application.Services.Interfaces.Email
{
    public interface IInfobipEmailService
    {
        Task<HttpResponseMessage> SendEmailAsync(string fromEmail, string toEmail, string subject, string body);
    }
}
