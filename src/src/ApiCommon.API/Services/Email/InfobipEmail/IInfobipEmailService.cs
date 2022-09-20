namespace ApiCommon.API.Services.Email.InfobipEmail
{
    public interface IInfobipEmailService
    {
        Task<HttpResponseMessage> SendEmailAsync(string fromEmail, string toEmail, string subject, string body);
    }
}
