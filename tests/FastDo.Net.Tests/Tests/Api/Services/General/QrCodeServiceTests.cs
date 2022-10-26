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

        [Fact]
        public void GenerateQrCode_Long_Text()
        {
            var qrCode = _qrCodeService.GenerateQrCode(
                @"Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of 
classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at 
Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum");

            Assert.NotNull(qrCode);
        }
    }
}
