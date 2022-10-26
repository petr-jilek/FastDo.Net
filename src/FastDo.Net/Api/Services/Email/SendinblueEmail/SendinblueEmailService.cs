using System.Text;

namespace FastDo.Net.Api.Services.Email.SendinblueEmail
{
    public class SendinblueEmailService : ISendinblueEmailService
    {
        private readonly SendinblueEmailServiceSettings _sendinblueEmailServiceSettings;

        public SendinblueEmailService(SendinblueEmailServiceSettings sendinblueEmailServiceSettings)
        {
            _sendinblueEmailServiceSettings = sendinblueEmailServiceSettings;
        }

        public async Task<HttpResponseMessage> SendEmailAsync(string fromEmail, string fromName, string toEmail,
            string toName, string subject, string htmlContent)
        {
            using var client = new HttpClient();

            client.BaseAddress = new Uri("https://api.sendinblue.com/v3/smtp/email");

            client.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json");
            client.DefaultRequestHeaders.TryAddWithoutValidation("content-type", "application/json");
            client.DefaultRequestHeaders.TryAddWithoutValidation("api-key", _sendinblueEmailServiceSettings.ApiKey);

            var jsonBody = "{\"sender\":{\"name\":\"" + fromName + "\",\"email\":\"" + fromEmail +
                           "\"},\"to\":[{\"email\":\"" + toEmail + "\",\"name\":\"" + toName + "\"}],\"subject\":\"" +
                           subject + "\",\"htmlContent\":\"" + htmlContent + "\"}";

            var result = await client.PostAsync("", new StringContent(jsonBody, Encoding.UTF8, "application/json"));

            return result;
        }
    }
}
