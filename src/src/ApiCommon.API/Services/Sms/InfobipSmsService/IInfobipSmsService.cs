namespace ApiCommon.API.Services.Sms.InfobipSmsService
{
    public interface IInfobipSmsService
    {
        Task<HttpResponseMessage> SendSmsAsync(string toPhoneNumber, string sender, string text);
    }
}
