using System.Drawing.Imaging;
using QRCoder;

namespace FastDo.Net.Api.Services.General.QrCode
{
    public class QrCodeService : IQrCodeService
    {
        public byte[] GenerateQrCode(string text)
        {
            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCode(qrCodeData);

            using var qrCodeImage = qrCode.GetGraphic(20);
            using var stream = new MemoryStream();

            qrCodeImage.Save(stream, ImageFormat.Png);
            return stream.ToArray();
        }
    }
}
