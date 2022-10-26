namespace FastDo.Net.Api.Services.Sms.InfobipSms
{
    public interface IInfobipSmsService
    {
        Task<HttpResponseMessage> SendSmsAsync(string toPhoneNumber, string sender, string text);
    }
}
