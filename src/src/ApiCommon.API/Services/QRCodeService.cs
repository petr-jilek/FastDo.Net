using System.Drawing;
using System.Drawing.Imaging;
using ApiCommon.Application.Interfaces;
using ApiCommon.Application.ServiceSettings;
using QRCoder;

namespace ApiCommon.API.Services
{
    public class QRCodeService : IQRCodeService
    {
        private readonly QRCodeServiceSettings _qRCodeServiceSettings;

        public QRCodeService(QRCodeServiceSettings qRCodeServiceSettings)
        {
            _qRCodeServiceSettings = qRCodeServiceSettings;
        }

        public string GenerateQRCode(string text)
        {
            var qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCode(qrCodeData);

            using (Bitmap qrCodeImage = qrCode.GetGraphic(20))
            {
                var directory = _qRCodeServiceSettings.Path;
                if (Directory.Exists(directory) == false)
                    Directory.CreateDirectory(directory);

                var path = Path.Combine(directory, text + ".png");
                qrCodeImage.Save(path, ImageFormat.Png);
            }

            return text;
        }
    }
}
