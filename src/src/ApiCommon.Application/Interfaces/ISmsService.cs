namespace ApiCommon.Application.Interfaces
{
    public interface ISmsService
    {
        Task SendSmsAsync(string toPhoneNumber, string text);
    }
}
