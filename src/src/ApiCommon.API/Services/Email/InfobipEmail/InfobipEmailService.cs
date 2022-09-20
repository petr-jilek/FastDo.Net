using System.Net.Http.Headers;

namespace ApiCommon.API.Services.Email.InfobipEmail
{
    public class InfobipEmailService : IInfobipEmailService
    {
        private readonly InfobipEmailServiceSettings _infobipEmailServiceSettings;

        public InfobipEmailService(InfobipEmailServiceSettings infobipEmailServiceSettings)
        {
            _infobipEmailServiceSettings = infobipEmailServiceSettings;
        }

        // private static readonly string BASE_URL = "https://4mw63m.api.infobip.com";
        //
        // private static readonly string
        //     API_KEY = "12148b9e998f021cb15db1b6f7097e64-f460c5e8-4f9c-4ff1-8a96-10487358c0bf";

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
