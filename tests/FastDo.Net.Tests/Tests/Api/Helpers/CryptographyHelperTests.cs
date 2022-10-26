using FastDo.Net.Api.Helpers;
using FastDo.Net.Domain.Enums;

namespace FastDo.Net.Tests.Tests.Api.Helpers
{
    public class CryptographyHelperTests
    {
        [Fact]
        public void GenerateRandomNumberFixedDigits_Test()
        {
            var digitsList = Enumerable.Range(1, 9).ToList();

            foreach (var digits in digitsList)
            {
                var randomInt = CryptographyHelper.GenerateRandomNumberFixedDigits(digits);

                Assert.Equal(randomInt.ToString().Length, digits);
            }
        }

        [Theory]
        [InlineData("Testdgfd365", "Testdgfd465")]
        [InlineData("sdhwhtae%$|%(*", "Testdgfd365")]
        [InlineData("Testdgfdgsd365", "Testdgfd365")]
        [InlineData("YT&Y*U(#IR", "Testdgfd365")]
        [InlineData("$MJTHG*Y(Jngh84igr4", "Testdgfd365")]
        [InlineData("51484551", "Testdgfd365")]
        [InlineData("gsdkhfu8&*(IO", "Testdgfd365")]
        public void Hashing_Test(string input, string differentInput)
        {
            var salt = CryptographyHelper.GenerateSalt();

            var hashSha256 = CryptographyHelper.CreateHash(input, salt, HashMethod.Sha256);
            var hashSha512 = CryptographyHelper.CreateHash(input, salt, HashMethod.Sha512);

            var verifySha256 = CryptographyHelper.Verify(input, hashSha256, salt, HashMethod.Sha256);
            var verifySha512 = CryptographyHelper.Verify(input, hashSha512, salt, HashMethod.Sha512);

            var verifySha256WrongHashMethod = CryptographyHelper.Verify(input, hashSha256, salt, HashMethod.Sha512);
            var verifySha512WrongHashMethod = CryptographyHelper.Verify(input, hashSha512, salt, HashMethod.Sha256);

            var verifySha256Different = CryptographyHelper.Verify(differentInput, hashSha256, salt, HashMethod.Sha256);
            var verifySha512Different = CryptographyHelper.Verify(differentInput, hashSha512, salt, HashMethod.Sha512);

            Assert.NotNull(salt);
            Assert.NotNull(hashSha256);
            Assert.NotNull(hashSha512);

            Assert.True(verifySha256);
            Assert.True(verifySha512);

            Assert.False(verifySha256WrongHashMethod);
            Assert.False(verifySha512WrongHashMethod);

            Assert.False(verifySha256Different);
            Assert.False(verifySha512Different);
        }
    }
}
