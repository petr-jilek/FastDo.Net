using System.Net.Http.Headers;
using System.Text;
using ApiCommon.Application.Services.Interfaces.Sms;
using ApiCommon.Application.Services.Settings.Sms;

namespace ApiCommon.API.Services.Sms
{
    public class InfobipSmsService : IInfobipSmsService
    {
        private readonly InfobipSmsServiceSettings _infobipSmsServiceSettings;

        public InfobipSmsService(InfobipSmsServiceSettings infobipSmsServiceSettings)
        {
            _infobipSmsServiceSettings = infobipSmsServiceSettings;
        }

        // private static readonly string BASE_URL = "https://4mw63m.api.infobip.com";
        // private static readonly string API_KEY = "12148b9e998f021cb15db1b6f7097e64-f460c5e8-4f9c-4ff1-8a96-10487358c0bf";

        public async Task<HttpResponseMessage> SendSmsAsync(string toPhoneNumber, string sender, string text)
        {
            if (_infobipSmsServiceSettings.BaseUrl is null) throw new ArgumentNullException();
            if (_infobipSmsServiceSettings.ApiKey is null) throw new ArgumentNullException();

            var client = new HttpClient();
            client.BaseAddress = new Uri(_infobipSmsServiceSettings.BaseUrl);
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
