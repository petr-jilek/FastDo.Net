using FastDo.Net.Api.Services.General.QrCode;

namespace FastDo.Net.Tests.Tests.Api.Services.General
{
    public class QrCodeServiceTests
    {
        private readonly IQrCodeService _qrCodeService;

        public QrCodeServiceTests()
        {
            _qrCodeService = new QrCodeService();
        }

        [Fact]
        public void GenerateQrCode_Ok()
        {
            var qrCode = _qrCodeService.GenerateQrCode("Test text");

            Assert.NotNull(qrCode);
        }
    }
}
