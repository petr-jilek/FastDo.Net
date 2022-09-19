namespace ApiCommon.Application.Services.Interfaces.Sms
{
    public interface IInfobipSmsService
    {
        Task<HttpResponseMessage> SendSmsAsync(string toPhoneNumber, string sender, string text);
    }
}
