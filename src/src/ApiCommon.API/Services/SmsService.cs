using System.Net.Http.Headers;
using System.Text;
using ApiCommon.Application.Interfaces;

namespace ApiCommon.API.Services
{
    public class SmsService : ISmsService
    {
        private static readonly string BASE_URL = "https://4mw63m.api.infobip.com";
        private static readonly string API_KEY = "12148b9e998f021cb15db1b6f7097e64-f460c5e8-4f9c-4ff1-8a96-10487358c0bf";

        private static readonly string SENDER = "InfoSMS";
        private static readonly string RECIPIENT = "420735995400";
        private static readonly string MESSAGE_TEXT = "This is a sample message";

        public async Task SendSmsAsync(string toPhoneNumber, string text)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(BASE_URL);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("App", API_KEY);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var message = $@"
            {{
                ""messages"": [
                {{
                    ""from"": ""{SENDER}"",
                    ""destinations"":
                    [
                        {{
                            ""to"": ""{RECIPIENT}""
                        }}
                  ],
                  ""text"": ""{text}""
                }}
              ]
            }}";

            var httpRequest = new HttpRequestMessage(HttpMethod.Post, "sms/2/text/advanced");
            httpRequest.Content = new StringContent(message, Encoding.UTF8, "application/json");

            var response = await client.SendAsync(httpRequest);
            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseContent);
        }
    }
}
