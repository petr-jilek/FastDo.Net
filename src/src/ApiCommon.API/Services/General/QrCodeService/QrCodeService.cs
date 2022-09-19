using System.Drawing.Imaging;
using QRCoder;

namespace ApiCommon.API.Services.General.QrCodeService
{
    public class QrCodeService : IQrCodeService
    {
        private readonly QRCodeServiceSettings _qRCodeServiceSettings;

        public QrCodeService(QRCodeServiceSettings qRCodeServiceSettings)
        {
            _qRCodeServiceSettings = qRCodeServiceSettings;
        }

        public string GenerateQrCode(string text)
        {
            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCode(qrCodeData);

            using var qrCodeImage = qrCode.GetGraphic(20);

            var directory = _qRCodeServiceSettings.Path!;
            if (Directory.Exists(directory) == false)
                Directory.CreateDirectory(directory);

            var path = Path.Combine(directory, text + ".png");
            qrCodeImage.Save(path, ImageFormat.Png);

            return text;
        }
    }
}
