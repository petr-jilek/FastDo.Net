using System.Net.Http.Headers;
using System.Text;

namespace ApiCommon.API.Services.Sms.InfobipSms
{
    public class InfobipSmsService : IInfobipSmsService
    {
        private readonly InfobipSmsServiceSettings _infobipSmsServiceSettings;

        public InfobipSmsService(InfobipSmsServiceSettings infobipSmsServiceSettings)
        {
            _infobipSmsServiceSettings = infobipSmsServiceSettings;
        }

        public async Task<HttpResponseMessage> SendSmsAsync(string toPhoneNumber, string sender, string text)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_infobipSmsServiceSettings.BaseUrl!);
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("App", _infobipSmsServiceSettings.ApiKey);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var message = $@"
            {{
                ""messages"": [
                {{
                    ""from"": ""{sender}"",
                    ""destinations"":
                    [
                        {{
                            ""to"": ""{toPhoneNumber}""
                        }}
                  ],
                  ""text"": ""{text}""
                }}
              ]
            }}";

            var httpRequest = new HttpRequestMessage(HttpMethod.Post, "sms/2/text/advanced");
            httpRequest.Content = new StringContent(message, Encoding.UTF8, "application/json");

            return await client.SendAsync(httpRequest);
        }
    }
}
