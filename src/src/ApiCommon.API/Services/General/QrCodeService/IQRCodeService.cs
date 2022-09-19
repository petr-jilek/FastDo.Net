namespace ApiCommon.API.Services.General.QrCodeService
{
    public interface IQrCodeService
    {
        string GenerateQrCode(string text);
    }
}
