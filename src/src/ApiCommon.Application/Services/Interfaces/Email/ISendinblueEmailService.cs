namespace ApiCommon.Application.Services.Interfaces.Email
{
    public interface ISendinblueEmailService
    {
        Task<HttpResponseMessage> SendEmailAsync(string fromEmail, string fromName, string toEmail, string toName, string subject, string htmlContent);
    }
}
