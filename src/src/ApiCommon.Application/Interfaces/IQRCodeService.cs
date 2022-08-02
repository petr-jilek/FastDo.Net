namespace ApiCommon.Application.Interfaces
{
    public interface IQRCodeService
    {
        string GenerateQRCode(string text);
    }
}
