using System.Net.Http.Headers;
using ApiCommon.Application.Interfaces;
using ApiCommon.Application.ServiceSettings;

namespace ApiCommon.API.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailServiceSettings _emailServiceSettings;

        public EmailService(EmailServiceSettings emailServiceSettings)
        {
            _emailServiceSettings = emailServiceSettings;
        }

        private static readonly string BASE_URL = "https://4mw63m.api.infobip.com";
        private static readonly string API_KEY = "12148b9e998f021cb15db1b6f7097e64-f460c5e8-4f9c-4ff1-8a96-10487358c0bf";
        private static readonly string SENDER_EMAIL = "petrjilek@selfserviceib.com";
        private static readonly string RECIPIENT_EMAIL = "petrjilek@centrum.cz";

        private static readonly string EMAIL_SUBJECT = "This is a sample email subject";
        private static readonly string EMAIL_TEXT = "This is a sample email message.";

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            //// Tutorial
            //// https://codewithmukesh.com/blog/send-emails-with-aspnet-core/

            //using var mail = new MailMessage();

            //mail.From = new MailAddress(_emailSettings.EmailAddress);
            //mail.To.Add(toEmail);
            //mail.Subject = subject;
            //mail.Body = body;
            //mail.IsBodyHtml = true;
            ////mail.Attachments.Add(new Attachment("C:\\file.zip"));

            //using var smtp = new SmtpClient(_emailSettings.Host, _emailSettings.Port);

            //smtp.Credentials = new NetworkCredential(_emailSettings.EmailAddress, _emailSettings.Password);
            //smtp.EnableSsl = true;
            //smtp.UseDefaultCredentials = false;
            //await smtp.SendMailAsync(mail);

            var client = new HttpClient();
            client.BaseAddress = new Uri(BASE_URL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("App", API_KEY);
            var request = new MultipartFormDataContent();
            request.Add(new StringContent(SENDER_EMAIL), "from");
            request.Add(new StringContent(RECIPIENT_EMAIL), "to");
            request.Add(new StringContent(EMAIL_SUBJECT), "subject");
            request.Add(new StringContent(body), "text");

            try
            {
                var response = client.PostAsync("email/2/send", request).Result;

                var responseContent = response.Content;
                var responseString = responseContent.ReadAsStringAsync().Result;
                var responseCode = response.StatusCode;
                Console.WriteLine("Status Code: " + responseCode);
                Console.WriteLine(responseString);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
