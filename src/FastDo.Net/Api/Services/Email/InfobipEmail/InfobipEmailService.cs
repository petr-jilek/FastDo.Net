using System.Net.Http.Headers;

namespace FastDo.Net.Api.Services.Email.InfobipEmail
{
    public class InfobipEmailService : IInfobipEmailService
    {
        private readonly InfobipEmailServiceSettings _infobipEmailServiceSettings;

        public InfobipEmailService(InfobipEmailServiceSettings infobipEmailServiceSettings)
        {
            _infobipEmailServiceSettings = infobipEmailServiceSettings;
        }

        public async Task<HttpResponseMessage> SendEmailAsync(string fromEmail, string toEmail, string subject,
            string body)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_infobipEmailServiceSettings.BaseUrl!);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("App", _infobipEmailServiceSettings.ApiKey);

            var request = new MultipartFormDataContent();
            request.Add(new StringContent(fromEmail), "from");
            request.Add(new StringContent(toEmail), "to");
            request.Add(new StringContent(subject), "subject");
            request.Add(new StringContent(body), "text");

            return await client.PostAsync("email/2/send", request);
        }
    }
}
