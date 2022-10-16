using System.Drawing.Imaging;
using QRCoder;

namespace FastDo.Net.Api.Services.General.QrCode
{
    public class QrCodeService : IQrCodeService
    {
        public byte[] GenerateQrCode(string input)
        {
            using var qrGenerator = new QRCodeGenerator();
            using var qrCodeData = qrGenerator.CreateQrCode(input, QRCodeGenerator.ECCLevel.Q);
            using var qrCode = new PngByteQRCode(qrCodeData);
            return qrCode.GetGraphic(20);
        }
    }
}
