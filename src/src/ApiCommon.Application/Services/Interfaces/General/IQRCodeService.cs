namespace ApiCommon.Application.Services.Interfaces.General
{
    public interface IQrCodeService
    {
        string GenerateQrCode(string text);
    }
}
