namespace FastDo.Net.Api.Services.General.QrCode
{
    public interface IQrCodeService
    {
        byte[] GenerateQrCode(string text);
    }
}
