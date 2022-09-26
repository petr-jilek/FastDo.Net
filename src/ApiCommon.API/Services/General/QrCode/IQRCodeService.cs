namespace ApiCommon.API.Services.General.QrCode
{
    public interface IQrCodeService
    {
        byte[] GenerateQrCode(string text);
    }
}
