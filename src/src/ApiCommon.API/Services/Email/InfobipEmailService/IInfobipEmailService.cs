namespace ApiCommon.API.Services.Email.InfobipEmailService
{
    public interface IInfobipEmailService
    {
        Task<HttpResponseMessage> SendEmailAsync(string fromEmail, string toEmail, string subject, string body);
    }
}
