using System.Text;
using System.Text.Json;
using FastDo.Net.Api.Services.Email.SendinblueEmail.Models;

namespace FastDo.Net.Api.Services.Email.SendinblueEmail
{
    public class SendinblueEmailService : ISendinblueEmailService
    {
        private readonly SendinblueEmailServiceSettings _sendinblueEmailServiceSettings;

        public SendinblueEmailService(SendinblueEmailServiceSettings sendinblueEmailServiceSettings)
        {
            _sendinblueEmailServiceSettings = sendinblueEmailServiceSettings;
        }

        public async Task<HttpResponseMessage> SendEmailAsync(EmailUser sender, EmailUser reciever, string subject, string htmlContent)
        {
            return await SendEmailMultipleRecieversAsync(sender, new List<EmailUser>() { reciever }, subject, htmlContent);
        }

        public async Task<HttpResponseMessage> SendEmailMultipleRecieversAsync(EmailUser sender, List<EmailUser> recievers, string subject, string htmlContent)
        {
            using var client = new HttpClient();

            client.BaseAddress = new Uri("https://api.sendinblue.com/v3/smtp/email");

            client.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json");
            client.DefaultRequestHeaders.TryAddWithoutValidation("content-type", "application/json");
            client.DefaultRequestHeaders.TryAddWithoutValidation("api-key", _sendinblueEmailServiceSettings.ApiKey);

            var jsonBody = JsonSerializer.Serialize(new
            {
                sender = sender,
                to = recievers,
                subject = subject,
                htmlContent = htmlContent,
            });

            var result = await client.PostAsync("", new StringContent(jsonBody, Encoding.UTF8, "application/json"));

            return result;
        }
    }
}
