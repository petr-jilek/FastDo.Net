namespace ApiCommon.API.Services.Email.SendinblueEmailService
{
    public interface ISendinblueEmailService
    {
        Task<HttpResponseMessage> SendEmailAsync(string fromEmail, string fromName, string toEmail, string toName, string subject, string htmlContent);
    }
}
